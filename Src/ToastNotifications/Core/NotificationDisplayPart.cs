using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToastNotifications.Display;
using ToastNotifications.Utilities;

namespace ToastNotifications.Core
{
    public abstract class NotificationDisplayPart : UserControl
    {
        protected INotificationAnimator Animator;
        protected INotification Notification { get; private set; }
        public virtual IMessageOptions Options { get; set; }

        protected NotificationDisplayPart()
        {
            Animator = new NotificationAnimator(this, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(300));

            Margin = new Thickness(1);

            Animator.Setup();

            Loaded += OnLoaded;
            MinHeight = 60;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Options?.NotificationClickAction?.Invoke(Notification);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            var dc = DataContext as INotification;
            var opts = dc?.DisplayPart?.Options;
            if (opts != null && opts.FreezeOnMouseEnter)
            {
                if (!opts.UnfreezeOnMouseLeave) // message stay freezed, show close button
                {
                    if (Content is Border)
                    {
                        if (dc.CanClose)
                        {
                            dc.CanClose = false;
                            var btn = this.FindChild<Button>("CloseButton");
                            btn.Visibility = Visibility.Visible;
                        }
                    }
                }
                else
                {
                    dc.CanClose = false;
                }
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            var opts = Notification?.DisplayPart?.Options;
            if (opts != null && opts.FreezeOnMouseEnter && opts.UnfreezeOnMouseLeave)
            {
                Notification.CanClose = true;
            }
            base.OnMouseLeave(e);
        }

        public virtual string GetMessage()
        {
            return Notification.Message;
        }

        public void Bind<TNotification>(TNotification notification) where TNotification : INotification
        {
            Notification = notification;
            DataContext = Notification;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Animator.PlayShowAnimation();
        }

        public void OnClose()
        {
            Animator.PlayHideAnimation();
        }
    }
}
