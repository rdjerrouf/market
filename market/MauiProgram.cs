using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using market.Data;
using Microsoft.EntityFrameworkCore;
using market.Services;
using market.Views;
using market.ViewModels;

namespace market
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Register services and DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=market.db")); // Example using SQLite
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<RegistrationViewModel>();
            builder.Services.AddTransient<RegistrationPage>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<ItemService>();
            builder.Services.AddScoped<MessageService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<SignInViewModel>();
            builder.Services.AddTransient<SignInPage>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "market.db");
                options.UseSqlite($"Data Source={dbPath}");
            });

            return builder.Build();
        }
    }
}