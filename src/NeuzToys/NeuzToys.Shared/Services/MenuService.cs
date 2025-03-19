using System.Collections.ObjectModel;
using NeuzToys.Shared.Models;

namespace NeuzToys.Shared.Services;

public class MenuService
{
    public ObservableCollection<MenuItem> MenuItems { get; } = [];

    public MenuService AddMenu(MenuItem menuItem)
    {
        MenuItems.Add(menuItem);
        return this;
    }
}