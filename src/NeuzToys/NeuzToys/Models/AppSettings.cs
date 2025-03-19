﻿using System;

namespace NeuzToys.Models;

public class AppSettings
{
    public string AppName { get; set; } = "NeuzToys";
    public string AppVersion { get; set; } = "0.0.1";
    public bool IsVisibleWelcomeWindow { get; set; } = true;
    
    public WelcomeSettings WelcomeSettings { get; set; } = new();
    public TitleBarSettings TitleBarSettings { get; set; } = new();
}

public class WelcomeSettings
{
    public string Title { get; set; } = "NeuzToys";
    public string SubTitle { get; set; } = "0.0.1";
    public string LoadingText { get; set; } = "Loading...";
    public int LoadingProgressSpeed { get; set; } = 10;
}

public class TitleBarSettings
{
    public Uri IconUri { get; set; } = new("avares://NeuzToys/Assets/logo.ico");

    /// <summary>
    ///     显示系统主题切换按钮
    /// </summary>
    public bool IsVisibleBtnSystemTheme { get; set; } = true;

    /// <summary>
    ///     显示Github按钮
    /// </summary>
    public bool IsVisibleBtnGithub { get; set; } = true;

    /// <summary>
    ///     Github按钮跳转Url
    /// </summary>
    public string BtnGithubUrl { get; set; } = "https://github.com/neuz/neuztoys";
}