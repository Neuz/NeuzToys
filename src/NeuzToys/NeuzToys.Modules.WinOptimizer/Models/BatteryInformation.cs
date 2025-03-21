namespace NeuzToys.Modules.WinOptimizer.Models;

public class BatteryInformation
{
    public int Number { get; set; }
    public string? Name { get; set; }
    /// <summary>
    /// 预计剩余电量
    /// </summary>
    public string? EstimatedChargeRemaining { get; set; }
    /// <summary>
    /// 电池状态
    /// </summary>
    public string? BatteryStatus { get; set; }
    /// <summary>
    /// 化学成分
    /// </summary>
    public string? Chemistry { get; set; }
}