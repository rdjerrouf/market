using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using market.Services;
using System.Threading.Tasks;

namespace market.ViewModels
{
    public partial class NotificationViewModel : ObservableObject
    {
        private readonly NotificationService _notificationService;

        [ObservableProperty]
        private string message = string.Empty;

        public NotificationViewModel(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [RelayCommand]
        private async Task SendNotificationAsync()
        {
            await _notificationService.SendNotificationAsync(Message);
        }
    }
}