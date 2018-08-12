using System.Windows;
using ToastNotifications.Core;
using ToastNotifications.Messages.Core;

namespace ToastNotifications.Messages.Warning
{
    public class WarningMessage : MessageBase<WarningDisplayPart>
    {
        public WarningMessage(string messageText) : this(messageText, new MessageOptions())
        {
        }

        public WarningMessage(string messageText, IMessageOptions options) : base(messageText, options)
        {
        }

        protected override WarningDisplayPart CreateDisplayPart()
        {
            return new WarningDisplayPart(this);
        }

        protected override void UpdateDisplayOptions(WarningDisplayPart displayPart, IMessageOptions options)
        {
            if (options.FontSize != null)
                displayPart.Text.FontSize = options.FontSize.Value;

            displayPart.CloseButton.Visibility = options.ShowCloseButton ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}