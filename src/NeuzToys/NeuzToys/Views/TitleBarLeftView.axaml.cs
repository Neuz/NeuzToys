using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.ViewModels;

namespace NeuzToys.Views;

public partial class TitleBarLeftView : UserControl
{
    public TitleBarLeftView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<TitleBarViewModel>();
    }
}