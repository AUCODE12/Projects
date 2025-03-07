using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelefonBozorNavoiBot.Bll.Services;
using TelefonBozorNavoiBot.Dal;

namespace TelefonBozorNavoiBot;

internal class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var botListenerService = services.GetRequiredService<BotListenerService>();

            await botListenerService.StartBot();
        }

        await host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<MainContext>(options =>
                    options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=TelefonBozorNavoiBot;TrustServerCertificate=True;"));

                services.AddScoped<IBotUserService, BotUserService>();
                services.AddScoped<IAnnouncementService, AnnouncementService>();
                services.AddSingleton<BotListenerService>();
            });
}
