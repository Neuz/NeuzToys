namespace NeuzToys.Modules.WinOptimizer.Models;

public class CpuInformation
{
    public int Number { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// 制造商
    /// </summary>
    public string? Manufacturer { get; set; }
    /// <summary>
    /// 架构
    /// </summary>
    public string? Architecture { get; set; }
    /// <summary>
    /// 核心数
    /// </summary>
    public string? Cores { get; set; }
    /// <summary>
    /// 逻辑核心数
    /// </summary>
    public string? LogicalProcessors { get; set; }
    /// <summary>
    /// 最大速度
    /// </summary>
    public string? MaxSpeed { get; set; }
    /// <summary>
    /// 插槽指定
    /// </summary>
    public string? SocketDesignation { get; set; }
    /// <summary>
    /// 二级缓存
    /// </summary>
    public string? L2Cache { get; set; }
    /// <summary>
    /// 三级缓存
    /// </summary>
    public string? L3Cache { get; set; }
}