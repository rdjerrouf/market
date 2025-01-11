using market.ViewModels;  // Ensure this using directive is included
using market.Models;
namespace market.Views;


public partial class ListingsPage : ContentPage
{
    public ListingsPage()
    {
        InitializeComponent();
        BindingContext = new ListingsViewModel();
    }
}
