using System.Collections.ObjectModel;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using NeuzToys.Services;
using NeuzToys.Shared.Models;
using NeuzToys.Shared.Services;
using NeuzToys.Shared.ViewModels;
using NeuzToys.Views;

namespace NeuzToys.ViewModels;

public partial class MenuViewModel:ViewModelBase
{
    [ObservableProperty] private bool _isCollapsed;
    [ObservableProperty] private ObservableCollection<MenuItem>? _menuItems;
    
    private AppService _app = Ioc.Default.GetRequiredService<AppService>();

    public MenuViewModel()
    {
        _menuItems = Ioc.Default.GetRequiredService<MenuService>().MenuItems;
    }
    
    [RelayCommand]
    private void SettingsWindowShowDialog()
    {
        if (_app.MainWindow == null) return;
        new SettingsWindow().ShowDialog(_app.MainWindow);
    }
}