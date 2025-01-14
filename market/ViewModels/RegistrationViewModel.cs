using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using market.Services;

namespace Dlala.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public RegistrationViewModel(AuthService authService)
        {
            _authService = authService;
        }

        private bool ValidateInput()
        {
            // Email validation
            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "Email is required";
                return false;
            }

            if (!IsValidEmail(Email))
            {
                return false;
            }

            // Password validation
            if (!IsValidPassword(Password))
            {
                return false;
            }

            // Username validation
            if (!IsValidUsername(Username))
            {
                return false;
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return false;
            }

            if (password.Contains(' '))
            {
                return false;
            }

            return true;
        }

        private static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            if (username.Length < 3)
            {
                return false;
            }

            if (!username.All(ch => char.IsLetterOrDigit(ch)))
            {
                return false;
            }

            return true;
        }

        [RelayCommand]
        private async Task Register()
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                if (await _authService.RegisterAsync(Username, Password, Email))
                {
                    await Shell.Current.DisplayAlert("Success", "Registration successful!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    ErrorMessage = "Registration failed. Username might already be taken.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }
    }
}