// ReSharper disable InconsistentNaming
namespace NeuzToys.Modules.WinOptimizer.Models;

public class GpuInformation
{
    public int Number { get; set; } = 0;
    /// <summary>
    /// 名称
    /// </summary>
    public string? Caption { get; set; }
    /// <summary>
    /// 适配器内存
    /// </summary>
    public string? AdapterRAM { get; set; }
    /// <summary>
    /// 驱动版本
    /// </summary>
    public string? DriverVersion { get; set; }
    /// <summary>
    /// 视频架构
    /// </summary>
    public string? VideoArchitecture { get; set; }
}