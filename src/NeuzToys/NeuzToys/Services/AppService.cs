﻿using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using NeuzToys.Models;

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
}

public partial class AppService
{
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