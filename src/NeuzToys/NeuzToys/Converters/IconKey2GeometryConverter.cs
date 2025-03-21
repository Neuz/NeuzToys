using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.Shared.Services;

namespace NeuzToys.Converters;

/// <summary>
/// IconKey -> Geometry
/// </summary>
public class IconKey2GeometryConverter:IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var icons = Ioc.Default.GetRequiredService<IconService>();
        if (value is string key) return icons.GetIcon(key) ?? AvaloniaProperty.UnsetValue;
        return AvaloniaProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return AvaloniaProperty.UnsetValue;
    }
}