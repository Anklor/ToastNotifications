﻿using System;

namespace ToastNotifications.Core
{
    public class MessageOptions: IMessageOptions
    {
        public double? FontSize { get; set; }
        public bool ShowCloseButton { get; set; }
        public object Tag { get; set; }
        public bool FreezeOnMouseEnter { get; set; }
        public bool UnfreezeOnMouseLeave { get; set; }

        public Action<INotification> NotificationClickAction { get; set; }
        public Action<INotification> CloseClickAction { get; set; }

        public MessageOptions()
        {
            ShowCloseButton = true;
            FreezeOnMouseEnter = true;
            UnfreezeOnMouseLeave = false;
        }
    }
}
