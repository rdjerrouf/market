using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using market.Services;  // Ensure this using directive is included

namespace market.ViewModels
{
    public partial class SignInViewModel : ObservableObject
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

        public ICommand SignInCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        private readonly AuthService _authService;

        public SignInViewModel(AuthService authService)
        {
            _authService = authService;
            SignInCommand = new RelayCommand(OnSignIn);
            NavigateToRegisterCommand = new RelayCommand(OnNavigateToRegister);
        }

        private async void OnSignIn()
        {
            bool success = await _authService.SignInAsync(Username, Password);
            if (success)
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Show error message
            }
        }

        private async void OnNavigateToRegister()
        {
            await Shell.Current.GoToAsync("RegistrationPage");
        }
    }
}
