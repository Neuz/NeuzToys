// ReSharper disable InconsistentNaming
namespace NeuzToys.Modules.WinOptimizer.Models;

public class NetworkInformation
{
    public int Number { get; set; } = 0;
    public string? Name { get; set; }
    /// <summary>
    /// Mac 地址
    /// </summary>
    public string? MACAddress { get; set; }
    /// <summary>
    /// 速度
    /// </summary>
    public string? Speed { get; set; }
    /// <summary>
    /// 适配器类型
    /// </summary>
    public string? AdapterType { get; set; }
}