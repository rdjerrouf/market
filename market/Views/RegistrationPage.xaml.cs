
using market.ViewModels; 
namespace market.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage(market.ViewModels.RegistrationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}