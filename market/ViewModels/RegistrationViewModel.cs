using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using market.Services;

namespace market.ViewModels
{

    public partial class RegistrationViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public RegistrationViewModel(AuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
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
                ErrorMessage = "Invalid email format";
                return false;
            }

            // Password validation
            if (!IsValidPassword(Password))
            {
                ErrorMessage = "Password must be at least 8 characters long, contain upper and lower case letters, a digit, and a special character";
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

        [RelayCommand]
        private async Task Register()
        {
            Console.WriteLine("Register command started");
            if (!ValidateInput())
            {
                Console.WriteLine("Input validation failed");
                return;
            }

            try
            {
                if (await _authService.RegisterAsync(Email, Password))
                {
                    await Shell.Current.DisplayAlert("Success", "Registration successful!", "OK");
                    Console.WriteLine("Register command successful");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    ErrorMessage = "Registration failed. Email might already be taken.";
                    Console.WriteLine("Register command failed");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
                Console.WriteLine($"Register command error: {ex.Message}");
            }
        }
    }
}

