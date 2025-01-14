using market.Views;


namespace market;


public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("RegistrationPage", typeof(RegistrationPage));
    }
}
