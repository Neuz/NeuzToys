using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using HotAvalonia;
using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Models;
using NeuzToys.Modules.WinOptimizer;
using NeuzToys.Services;
using NeuzToys.Shared.Extensions;
using NeuzToys.Shared.Services;
using NeuzToys.ViewModels;
using NeuzToys.Views;
using Serilog;
using Serilog.Events;

namespace NeuzToys;

public class App : Application
{
    public override void Initialize()
    {
        this.EnableHotReload(); // 开发时热加载扩展
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        #region 依赖注入

        var menuService = new MenuService();
        var provider = new ServiceCollection()
            .AddSingleton(menuService)
            .InitModule<BaseModule>(menuService)
            .InitModule<WinOptimizerModule>(menuService)
            .BuildServiceProvider();

        Ioc.Default.ConfigureServices(provider);

        #endregion


        var mainWindow = new MainWindow { DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>() };

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            var appService = Ioc.Default.GetRequiredService<AppService>();

            #region 日志

            var loggerSettings = appService.AppSettings.LoggerSettings;
            var path = Path.Combine(loggerSettings.LogFilePath, "log.log");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(path: path,
                    shared: true,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: loggerSettings.OutputTemplate)
                .CreateLogger();

            // 订阅未处理异常
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                Log.Write(LogEventLevel.Error, (Exception)e.ExceptionObject, "Unhandled exception");
            TaskScheduler.UnobservedTaskException += (s, e) =>
                Log.Write(LogEventLevel.Error, e.Exception, "Unobserved task exception");

            desktop.Startup += (s, e) => Log.Information("启动");
            desktop.Exit += (s, e) => Log.Information("关闭");

            #endregion

            // 是否启用Welcome窗体
            desktop.MainWindow = appService.AppSettings.IsVisibleWelcomeWindow
                ? new WelcomeWindow(mainWindow)
                    { DataContext = Ioc.Default.GetRequiredService<WelcomeWindowViewModel>() }
                : mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove) BindingPlugins.DataValidators.Remove(plugin);
    }

    private void ShowWindow_OnClicked(object? sender, EventArgs e)
    {
        if (ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        desktop.MainWindow?.Show();
        desktop.MainWindow?.Activate();
    }

    private void ExitApp_OnClicked(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}