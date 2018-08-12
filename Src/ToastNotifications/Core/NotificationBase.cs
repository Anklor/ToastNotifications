using System;

namespace ToastNotifications.Core
{
    public abstract class NotificationBase : INotification
    {
        public int Id { get; set; }

        private Action<INotification> _closeAction;

        public bool CanClose { get; set; } = true;

        public abstract NotificationDisplayPart DisplayPart { get; }

        public INotificationConfiguration Configuration { get; set; }

        public virtual void Bind(Action<INotification> closeAction)
        {
            _closeAction = closeAction;
        }

        public virtual void Close()
        {
            Configuration.CloseClickAction?.Invoke(this);
            _closeAction?.Invoke(this);
        }

        public string Message => DisplayPart.GetMessage();
    }
}