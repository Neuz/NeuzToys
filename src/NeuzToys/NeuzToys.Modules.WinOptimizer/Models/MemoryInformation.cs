namespace NeuzToys.Modules.WinOptimizer.Models;

public class MemoryInformation
{
    public int Number { get; set; } = 0;
    /// <summary>
    /// 设备定位器
    /// </summary>
    public string? DeviceLocator { get; set; }
    /// <summary>
    /// 容量
    /// </summary>
    public string? Capacity { get; set; }
    /// <summary>
    /// 速度
    /// </summary>
    public string? Speed { get; set; }
    /// <summary>
    /// 制造商
    /// </summary>
    public string? Manufacturer { get; set; }
}