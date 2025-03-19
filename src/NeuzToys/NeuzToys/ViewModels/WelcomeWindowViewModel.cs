using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Irihi.Avalonia.Shared.Contracts;
using NeuzToys.Models;
using NeuzToys.Services;

namespace NeuzToys.ViewModels;

public partial class WelcomeWindowViewModel : ObservableObject, IDialogContext
{
    [ObservableProperty] private double _progress;

    public WelcomeSettings Settings => _appService.AppSettings.WelcomeSettings;

    private readonly AppService _appService = Ioc.Default.GetRequiredService<AppService>();
    private readonly Random _random = new();


    public WelcomeWindowViewModel()
    {
        DispatcherTimer.Run(OnUpdate, TimeSpan.FromMilliseconds(20), DispatcherPriority.Default);
    }

    private bool OnUpdate()
    {
        Progress += Settings.LoadingProgressSpeed * _random.NextDouble();
        if (Progress <= 100) return true;
        RequestClose?.Invoke(this, true);
        return false;
    }

    public void Close()
    {
        RequestClose?.Invoke(this, false);
    }

    public event EventHandler<object?>? RequestClose;
}