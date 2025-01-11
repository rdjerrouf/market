using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using market.Services;  // Ensure this using directive is included

namespace market.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateToSignInCommand { get; }

        private readonly AuthService _authService;

        public RegistrationViewModel(AuthService authService)
        {
            _authService = authService;
            RegisterCommand = new RelayCommand(OnRegister);
            NavigateToSignInCommand = new RelayCommand(OnNavigateToSignIn);
        }

        private async void OnRegister()
        {
            if (Password == ConfirmPassword)
            {
                bool success = await _authService.RegisterAsync(Username, Password);
                if (success)
                {
                    await Shell.Current.GoToAsync("SignInPage");
                }
                else
                {
                    // Show error message
                }
            }
            else
            {
                // Show password mismatch message
            }
        }

        private async void OnNavigateToSignIn()
        {
            await Shell.Current.GoToAsync("SignInPage");
        }
    }
}
