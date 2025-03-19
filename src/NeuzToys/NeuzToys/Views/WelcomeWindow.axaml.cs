using System.Threading.Tasks;
using Avalonia.Controls;
using Ursa.Controls;

namespace NeuzToys.Views;

public partial class WelcomeWindow : SplashWindow
{
    private readonly MainWindow _mainWindow;

    public WelcomeWindow(MainWindow mainWindow)
    {
        InitializeComponent();
        _mainWindow = mainWindow;
    }

    protected override Task<Window?> CreateNextWindow()
    {
        return DialogResult is true
            ? Task.FromResult<Window?>(_mainWindow)
            : Task.FromResult<Window?>(null);
    }
}