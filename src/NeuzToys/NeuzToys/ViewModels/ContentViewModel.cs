using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using NeuzToys.Shared.Messages;
using NeuzToys.Shared.ViewModels;

namespace NeuzToys.ViewModels;

public partial class ContentViewModel : ViewModelBase
{
    [ObservableProperty] private object? _content;


    public ContentViewModel()
    {
        WeakReferenceMessenger.Default.Register<ContentViewModel, MenuActivateMessage>(this, OnNavigation);
    }

    private void OnNavigation(ContentViewModel recipient, MenuActivateMessage message)
    {
        try
        {
            var viewModelType = message.MenuItem?.ViewModelType;
            if (viewModelType == null)
            {
                Content = null;
                return;
            }

            Content = Ioc.Default.GetService(viewModelType);
        }
        catch (Exception)
        {
            Content = null;
        }
    }
}