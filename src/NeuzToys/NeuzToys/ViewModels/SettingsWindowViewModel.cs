using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using NeuzToys.Models;
using NeuzToys.Services;
using NeuzToys.Shared.ViewModels;

namespace NeuzToys.ViewModels;

public partial class SettingsWindowViewModel:ViewModelBase
{
    private readonly AppService _appService = Ioc.Default.GetRequiredService<AppService>();
    public Bitmap Icon => _appService.AssertLoadBitmap("avares://NeuzToys/Assets/logo.ico");

    public bool IsHideToTray => _appService.AppSettings.ConfigSettings.IsHideToTray;

    public SettingsWindowViewModel()
    {
    }

    [RelayCommand]
    private async Task SetIsHideToTray(bool value)
    {
        _appService.AppSettings.ConfigSettings.IsHideToTray = value;
        await _appService.SaveConfigAsync();
    }

}