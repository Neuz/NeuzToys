using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using NeuzToys.Modules.WinOptimizer.Models;
using NeuzToys.Modules.WinOptimizer.Services;
using NeuzToys.Shared;
using NeuzToys.Shared.Services;
using NeuzToys.Shared.ViewModels;

namespace NeuzToys.Modules.WinOptimizer.ViewModels;

public partial class SystemInfoViewModel : ViewModelBase
{
    private WmiService _wmi = Ioc.Default.GetRequiredService<WmiService>();

    [ObservableProperty] private OSInformation? _osInfo;
    [ObservableProperty] private ObservableCollection<CpuInformation> _cpuInfos;
    [ObservableProperty] private ObservableCollection<GpuInformation> _gpuInfos;
    [ObservableProperty] private ObservableCollection<MemoryInformation> _memInfos;
    [ObservableProperty] private ObservableCollection<DiskInformation> _diskInfos;
    [ObservableProperty] private ObservableCollection<NetworkInformation> _networkInfos;
    [ObservableProperty] private ObservableCollection<BatteryInformation> _batteryInfos;

    [ObservableProperty] private bool _loading;


    public SystemInfoViewModel()
    {
        Reload();
    }


    [RelayCommand]
    private async void Reload()
    {
        Loading = true;
        await Task.Run(async () =>
        {
            OsInfo = (await _wmi.GetOSInformationAsync()).FirstOrDefault() ?? new OSInformation();
            CpuInfos = new ObservableCollection<CpuInformation>(await _wmi.GetCpuInformationAsync());
            GpuInfos = new ObservableCollection<GpuInformation>(await _wmi.GetGpuInformationAsync());
            MemInfos = new ObservableCollection<MemoryInformation>(await _wmi.GetMemoryInformationAsync());
            DiskInfos = new ObservableCollection<DiskInformation>(await _wmi.GetDiskInformationAsync());
            NetworkInfos = new ObservableCollection<NetworkInformation>(await _wmi.GetNetworkInformationAsync());
            BatteryInfos = new ObservableCollection<BatteryInformation>(await _wmi.GetBatteryInformationAsync());
        });
        Loading = false;
    }
}