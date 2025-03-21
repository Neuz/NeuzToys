// ReSharper disable InconsistentNaming
namespace NeuzToys.Modules.WinOptimizer.Models;

public class OSInformation
{
    /// <summary>
    /// 操作系统名称
    /// </summary>
    public string? OSName { get; set; }
    /// <summary>
    /// 版本
    /// </summary>
    public string? OSVersion { get; set; }
    /// <summary>
    /// 内部版本号
    /// </summary>
    public string? BuildNumber { get; set; }
    /// <summary>
    /// 架构
    /// </summary>
    public string? Architecture { get; set; }
    /// <summary>
    /// 安装日期
    /// </summary>
    public string? InstallDate { get; set; }
    /// <summary>
    /// 注册用户
    /// </summary>
    public string? RegisteredUser { get; set; }
    /// <summary>
    /// Windows目录
    /// </summary>
    public string? WindowsDirectory { get; set; }
    /// <summary>
    /// 系统目录
    /// </summary>
    public string? SystemDirectory { get; set; }
    /// <summary>
    /// 最后启动时间
    /// </summary>
    public string? LastBootUpTime { get; set; }
}