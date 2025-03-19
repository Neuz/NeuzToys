using System;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using NeuzToys.Models;
using NeuzToys.Services;

namespace NeuzToys.ViewModels;

public partial class TitleBarViewModel : ViewModelBase
{
    private readonly AppService _appService = Ioc.Default.GetRequiredService<AppService>();

    public AppSettings AppSettings => _appService.AppSettings;
    public TitleBarSettings TitleBarSettings => _appService.AppSettings.TitleBarSettings;


    public Bitmap Icon => _appService.AssertLoadBitmap(TitleBarSettings.IconUri);

    [RelayCommand]
    private void OpenGithub()
    {
        _appService.OpenUrlAsync(TitleBarSettings.BtnGithubUrl);
    }
}