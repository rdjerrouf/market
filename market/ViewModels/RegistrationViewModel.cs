using market.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace market.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        // Parameterless constructor for XAML binding
        public RegistrationViewModel() { }

        // Constructor for dependency injection
        public RegistrationViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task Register()
        {
            if (await _authService.RegisterAsync(Username, Password, Email))
            {
                ErrorMessage = string.Empty; // Handle successful registration
            }
            else
            {
                ErrorMessage = "Registration failed. Username might already be taken."; // Handle unsuccessful registration
            }
        }
    }
}