using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.Models;
using NeuzToys.Services;
using NeuzToys.Shared.ViewModels;

namespace NeuzToys.ViewModels;

public class SettingsWindowViewModel:ViewModelBase
{
    private readonly AppService _appService = Ioc.Default.GetRequiredService<AppService>();
    public Bitmap Icon => _appService.AssertLoadBitmap("avares://NeuzToys/Assets/logo.ico");
    public string Title => "设置";

    public string GeneralHeader => "通用设置";
    public string AboutHeader => "关于";
    public string AboutContent => "这里是关于";
}