using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.ViewModels;
using Ursa.Controls;

namespace NeuzToys.Views;

public partial class SettingsWindow : UrsaWindow
{
    public SettingsWindow()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<SettingsWindowViewModel>();
    }
}