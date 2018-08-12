using System;

namespace ToastNotifications.Core
{
    public interface IMessageOptions
    {
        double? FontSize { get; set; }
        bool ShowCloseButton { get; set; }
        object Tag { get; set; }
        bool FreezeOnMouseEnter { get; set; }
        bool UnfreezeOnMouseLeave { get; set; }

        Action<INotification> NotificationClickAction { get; set; }
        Action<INotification> CloseClickAction { get; set; }
    }
}
