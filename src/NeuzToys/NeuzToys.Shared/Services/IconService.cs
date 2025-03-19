using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media;
using Semi.Avalonia;

namespace NeuzToys.Shared.Services;

public class IconService
{
    private readonly Dictionary<string, Geometry> _icons = new();
    
    public IconService()
    {
        foreach (var provider in new Icons().MergedDictionaries)
        {
            if (provider is not ResourceDictionary dict) continue;
            foreach (var key in dict.Keys)
            {
                if (string.IsNullOrEmpty(key.ToString())) continue;
                if (dict[key] is not Geometry geometry) continue;
                _icons[key.ToString().ToLower()] = geometry;
            }
        }
    }
    
    public Geometry? GetIcon(string key)
    {
        _icons.TryGetValue(key.ToLower(), out var geometry);
        return geometry;
    }
}