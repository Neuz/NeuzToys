using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.ViewModels;

namespace NeuzToys.Views;

public partial class MenuView : UserControl
{
    public MenuView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<MenuViewModel>();
    }
}