using Microsoft.Extensions.DependencyInjection;
using NavoiyTelefonBozorBot.Bot;
using NavoiyTelefonBozorBot.Database;
using NavoiyTelefonBozorBot.Service;
using Telegram.Bot;

var services = new ServiceCollection()
    .AddSingleton(new TelegramBotClient("7644272652:AAHEBPvxfe0_ggcLAapDwvjEOPfAh6A7NY8"))
    .AddSingleton<AppDbContext>()
    .AddSingleton<CommandHandler>()
    .AddSingleton<BotService>()
    .AddSingleton<AnnouncementService>()
    .BuildServiceProvider();

var botService = services.GetRequiredService<BotService>();
await botService.StartAsync();
