using System.Windows;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Core
{
    public abstract class MessageBase<TDisplayPart> : NotificationBase where TDisplayPart : NotificationDisplayPart
    {
        public string MessageText { get; }

        public IMessageOptions Options { get; }

        private NotificationDisplayPart _displayPart;
        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = Configure());

        protected MessageBase(string messageText, IMessageOptions options)
        {
            MessageText = messageText;
            Options = options ?? new MessageOptions();
        }

        private TDisplayPart Configure()
        {
            TDisplayPart displayPart = CreateDisplayPart();

            displayPart.Unloaded += OnUnloaded;

            UpdateDisplayOptions(displayPart, Options);
            return displayPart;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _displayPart.Unloaded -= OnUnloaded;
        }

        protected abstract void UpdateDisplayOptions(TDisplayPart displayPart, IMessageOptions options);

        protected abstract TDisplayPart CreateDisplayPart();
    }
}