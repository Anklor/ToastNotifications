using System;

namespace ToastNotifications.Core
{
    public abstract class NotificationBase : INotification
    {
        private Action<INotification> _closeAction;

        public bool CanClose { get; set; } = true;

        public abstract NotificationDisplayPart DisplayPart { get; }

        public int Id { get; set; }

        public virtual void Bind(Action<INotification> closeAction)
        {
            _closeAction = closeAction;
        }

        public virtual void Close()
        {
            if (DisplayPart.Options is IMessageOptions opts)
            {
                opts.CloseClickAction?.Invoke(this);
            }
            _closeAction?.Invoke(this);
        }

        public string Message => DisplayPart.GetMessage();
    }
}