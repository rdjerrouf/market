using market.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace market.ViewModels
{
    public partial class SignInViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        // Parameterless constructor for XAML binding
        public SignInViewModel() { }

        // Constructor for dependency injection
        public SignInViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task SignIn()
        {
            if (await _authService.SignInAsync(Username, Password))
            {
                ErrorMessage = string.Empty; // Handle successful sign-in
            }
            else
            {
                ErrorMessage = "Invalid username or password."; // Handle unsuccessful sign-in
            }
        }
    }
}