using System.Windows;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Warning
{
    /// <summary>
    /// Interaction logic for WarningDisplayPart.xaml
    /// </summary>
    public partial class WarningDisplayPart : NotificationDisplayPart
    {
        private readonly WarningMessage _viewModel;

        public WarningDisplayPart(WarningMessage warning)
        {
            InitializeComponent();

            _viewModel = warning;
            Bind(_viewModel);
        }

        public override string GetMessage()
        {
            return this._viewModel.MessageText;
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }

        public override IMessageOptions Options => this._viewModel.Options;
    }
}
