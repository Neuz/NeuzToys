using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using NeuzToys.Models;
using Serilog;

namespace NeuzToys.Services;

public partial class AppService
{
    public AppSettings AppSettings { get; set; } = new();

    public Window? MainWindow =>
        Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;

    public IStorageProvider? StorageProvider => MainWindow?.StorageProvider;

    public ILauncher? Launcher => MainWindow?.Launcher;

    public AppService()
    {
        _ = LoadConfigAsync();
    }
}

public partial class AppService
{
    /// <summary>
    /// 保存配置
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task SaveConfigAsync()
    {
        try
        {
            var settings = AppSettings.ConfigSettings;
            var text = JsonSerializer.Serialize(settings, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });
            Directory.CreateDirectory(Path.GetDirectoryName(settings.ConfigFile)
                                      ?? throw new InvalidOperationException($"保存配置失败，目录为空。[{settings.ConfigFile}]"));
            await File.WriteAllTextAsync(settings.ConfigFile, text, new UTF8Encoding(false));
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    /// <summary>
    /// 加载配置
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task LoadConfigAsync()
    {
        var settings = AppSettings.ConfigSettings;
        try
        {
            if (!File.Exists(settings.ConfigFile))
            {
                await SaveConfigAsync();
            }

            var text = await File.ReadAllTextAsync(settings.ConfigFile);
            AppSettings.ConfigSettings = JsonSerializer.Deserialize<ConfigSettings>(text)
                                         ?? throw new InvalidOperationException($"加载配置失败。[{settings.ConfigFile}]");
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }
    }

    /// <summary>
    ///     打开url
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async void OpenUrlAsync(string url)
    {
        if (Launcher == null) return;
        await Launcher.LaunchUriAsync(new Uri(url));
    }

    /// <summary>
    ///     加载Assert
    /// </summary>
    /// <param name="uriStr"></param>
    /// <returns></returns>
    public Bitmap AssertLoadBitmap(string uriStr)
    {
        return AssertLoadBitmap(new Uri(uriStr));
    }

    /// <summary>
    ///     加载Assert
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    public Bitmap AssertLoadBitmap(Uri uri)
    {
        return new Bitmap(AssetLoader.Open(uri));
    }
}