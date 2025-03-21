using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.DependencyInjection;
using NeuzToys.Shared.Services;
using NeuzToys.Shared.ViewModels;
using MenuItem = NeuzToys.Shared.Models.MenuItem;

// ReSharper disable ReplaceWithSingleCallToFirstOrDefault

namespace NeuzToys.DataTemplates;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null) return null;

        var menuService = Ioc.Default.GetRequiredService<MenuService>();

        // 展开所有子项
        IEnumerable<MenuItem> Flatten(IEnumerable<MenuItem> collection)
        {
            foreach (var item in collection)
            {
                if (item.Children.Count > 0)
                    foreach (var c in Flatten(item.Children))
                        yield return c;
                yield return item;
            }
        }

        var viewType = Flatten(menuService.MenuItems)
            .Where(m => m.ViewModelType != null)
            .Where(m => m.ViewType != null)
            .Where(m => m.ViewModelType == param.GetType())
            .FirstOrDefault()?.ViewType;

        if (viewType is null) return new TextBlock { Text = "ViewType Not Found: " };

        return (Control)Activator.CreateInstance(viewType)!;
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}