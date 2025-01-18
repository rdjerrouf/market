using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace market.Services
{
    public class NotificationService
    {
        public async Task SendNotificationAsync(string message)
        {
            // Simulate sending a notification
            await Task.Delay(1000);
            Console.WriteLine($"Notification sent: {message}");
        }
    }
}