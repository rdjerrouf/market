using market.ViewModels;
using market.Services;

namespace market.Views
{
    public partial class SignInPage : ContentPage
    {
        private readonly SignInViewModel _viewModel;

        public SignInPage(SignInViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}