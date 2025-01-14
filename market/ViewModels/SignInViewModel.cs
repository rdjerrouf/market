using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using market.Services;

namespace market.ViewModels
{
    public partial class SignInViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        // Remove the parameterless constructor
        public SignInViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task SignInAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter both email and password";
                return;
            }

            try
            {
                if (await _authService.SignInAsync(Email, Password))
                {
                    // Sign in successful
                    ErrorMessage = string.Empty;
                    await Shell.Current.GoToAsync("///MainPage");
                }
                else
                {
                    ErrorMessage = "Invalid email or password";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }

        [RelayCommand]
        private async Task NavigateToRegister()
        {
            try
            {
                await Shell.Current.DisplayAlert("Debug", "Starting navigation...", "OK");
                await Shell.Current.GoToAsync("RegistrationPage");
                await Shell.Current.DisplayAlert("Debug", "Navigation completed", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }
    }
}