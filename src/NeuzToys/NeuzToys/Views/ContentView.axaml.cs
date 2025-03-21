using Avalonia.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.ViewModels;

namespace NeuzToys.Views;

public partial class ContentView : UserControl
{
    public ContentView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<ContentViewModel>();
    }
}