using System.Windows;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Success
{
    /// <summary>
    /// Interaction logic for SuccessDisplayPart.xaml
    /// </summary>
    public partial class SuccessDisplayPart : NotificationDisplayPart
    {
        private readonly SuccessMessage _viewModel;

        public SuccessDisplayPart(SuccessMessage success)
        {
            InitializeComponent();

            _viewModel = success;
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
