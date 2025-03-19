using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using NeuzToys.Shared.Messages;

namespace NeuzToys.Shared.Models;

public class MenuItem
{
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = "SemiIconArchive";
    public ICommand ActivateCommand { get; }
    public Type ViewModelType { get; set; }
    public Type ViewType { get; set; }
    public ObservableCollection<MenuItem> Children { get; set; } = new();

    private void OnActivate()
    {
        if (string.IsNullOrEmpty(Key)) return;
        WeakReferenceMessenger.Default.Send(new MenuActivateMessage(this));
    }
}