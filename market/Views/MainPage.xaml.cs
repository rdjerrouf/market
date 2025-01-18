using market.ViewModels;

namespace market.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = BindingContext as MainViewModel;
            viewModel?.SearchCommand.Execute(e.NewTextValue);
        }
    }
}
