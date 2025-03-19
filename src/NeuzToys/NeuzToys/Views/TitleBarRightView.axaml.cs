using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.ViewModels;

namespace NeuzToys.Views;

public partial class TitleBarRightView : UserControl
{
    public TitleBarRightView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<TitleBarViewModel>();
    }
}