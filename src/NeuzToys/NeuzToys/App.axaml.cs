using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NeuzToys.Services;
using NeuzToys.Shared.Extensions;
using NeuzToys.Shared.Services;
using NeuzToys.ViewModels;
using NeuzToys.Views;

namespace NeuzToys;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        #region 依赖注入

        var menuService = new MenuService();
        var provider = new ServiceCollection()
            .InitModule<MainModule>(menuService)
            .BuildServiceProvider();

        Ioc.Default.ConfigureServices(provider);

        #endregion

        var mainWindow = new MainWindow { DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>() };
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            var appService = Ioc.Default.GetRequiredService<AppService>();
            
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