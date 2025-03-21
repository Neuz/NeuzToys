using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using NeuzToys.Modules.WinOptimizer.Models;

// ReSharper disable InconsistentNaming

namespace NeuzToys.Modules.WinOptimizer.Services;

public class WmiService
{
    public async Task<IEnumerable<OSInformation>> GetOSInformationAsync() => await Task.Run(GetOSInformation);
    public async Task<IEnumerable<CpuInformation>> GetCpuInformationAsync() => await Task.Run(GetCpuInformation);
    public async Task<IEnumerable<GpuInformation>> GetGpuInformationAsync() => await Task.Run(GetGpuInformation);
    public async Task<IEnumerable<MemoryInformation>> GetMemoryInformationAsync() => await Task.Run(GetMemoryInformation);
    public async Task<IEnumerable<DiskInformation>> GetDiskInformationAsync() => await Task.Run(GetDiskInformation);
    public async Task<IEnumerable<NetworkInformation>> GetNetworkInformationAsync() => await Task.Run(GetNetworkInformation);
    public async Task<IEnumerable<BatteryInformation>> GetBatteryInformationAsync() => await Task.Run(GetBatteryInformation);

    public IEnumerable<OSInformation> GetOSInformation()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select(os => new OSInformation
                {
                    OSName = $"{os["Caption"]}",
                    OSVersion = $"{os["Version"]}",
                    BuildNumber = $"{os["BuildNumber"]}",
                    Architecture = $"{os["OSArchitecture"]}",
                    InstallDate = $"{os["InstallDate"]}",
                    RegisteredUser = $"{os["RegisteredUser"]}",
                    WindowsDirectory = $"{os["WindowsDirectory"]}",
                    SystemDirectory = $"{os["SystemDirectory"]}",
                    LastBootUpTime = $"{os["LastBootUpTime"]}"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IEnumerable<CpuInformation> GetCpuInformation()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select((cpu, i) => new CpuInformation
                {
                    Number = i,
                    Name = $"{cpu["Name"]}",
                    Manufacturer = $"{cpu["Manufacturer"]}",
                    Architecture = $"{cpu["Architecture"]}",
                    Cores = $"{cpu["NumberOfCores"]}",
                    LogicalProcessors = $"{cpu["NumberOfLogicalProcessors"]}",
                    MaxSpeed = $"{cpu["MaxClockSpeed"]} MHz",
                    SocketDesignation = $"{cpu["SocketDesignation"]}",
                    L2Cache = $"{cpu["L2CacheSize"]} KB",
                    L3Cache = $"{cpu["L3CacheSize"]} KB"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IEnumerable<GpuInformation> GetGpuInformation()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select((gpu, i) => new GpuInformation
                {
                    Number = i,
                    Caption = $"{gpu["Caption"]}",
                    AdapterRAM = $"{gpu["AdapterRAM"]} bytes",
                    DriverVersion = $"{gpu["DriverVersion"]}",
                    VideoArchitecture = $"{gpu["VideoArchitecture"]}"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IEnumerable<MemoryInformation> GetMemoryInformation()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select((mem, i) => new MemoryInformation
                {
                    Number = i,
                    DeviceLocator = $"{mem["DeviceLocator"]}",
                    Capacity = $"{(ulong)mem["Capacity"] / (1024 * 1024)} MB",
                    Speed = $"{mem["Speed"]} MHz",
                    Manufacturer = $"{mem["Manufacturer"]}"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IEnumerable<DiskInformation> GetDiskInformation()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select((disk, i) => new DiskInformation
                {
                    Number = i,
                    Caption = $"{disk["Caption"]}",
                    Size = $"{disk["Size"]} bytes",
                    InterfaceType = $"{disk["InterfaceType"]}",
                    Manufacturer = $"{disk["Manufacturer"]}",
                    Model = $"{disk["Model"]}"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IEnumerable<NetworkInformation> GetNetworkInformation()
    {
        try
        {
            using var searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = TRUE");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select((network, i) => new NetworkInformation
                {
                    Number = i,
                    Name = $"{network["Name"]}",
                    MACAddress = $"{network["MACAddress"]}",
                    Speed = $"{network["Speed"]} bps",
                    AdapterType = $"{network["AdapterType"]}"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IEnumerable<BatteryInformation> GetBatteryInformation()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");
            var collection = searcher.Get();

            return collection.Cast<ManagementObject>()
                .Select((b, i) => new BatteryInformation
                {
                    Number = i,
                    Name = $"{b["Name"]}",
                    EstimatedChargeRemaining = $"{b["EstimatedChargeRemaining"]}%",
                    BatteryStatus = $"{b["BatteryStatus"]}",
                    Chemistry = $"{b["Chemistry"]}"
                });
        }
        catch (Exception)
        {
            return [];
        }
    }
}