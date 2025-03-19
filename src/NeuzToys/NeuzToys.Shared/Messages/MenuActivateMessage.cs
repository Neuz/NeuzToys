using CommunityToolkit.Mvvm.Messaging.Messages;
using NeuzToys.Shared.Models;

namespace NeuzToys.Shared.Messages;

public class MenuActivateMessage : ValueChangedMessage<MenuItem>
{
    public MenuActivateMessage(MenuItem menuItem) : base(menuItem)
    {
        MenuItem = menuItem;
    }

    public MenuItem? MenuItem { get; private set; }
}