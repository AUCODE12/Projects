using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;

namespace NavoiyTelefonBozorBot.Bot;

public class BotService
{
    private readonly ITelegramBotClient _botClient;
    private readonly CommandHandler _commandHandler;

    public BotService(string token, CommandHandler commandHandler)
    {
        _botClient = new TelegramBotClient(token);
        _commandHandler = commandHandler;
    }

    public async Task StartAsync()
    {
        var cts = new CancellationTokenSource();
        _botClient.StartReceiving(UpdateHandler, ErrorHandler, new ReceiverOptions(), cts.Token);
        Console.WriteLine("🤖 Bot ishga tushdi...");
        await Task.Delay(-1);
    }

    private async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            await _commandHandler.HandleUpdateAsync(update);
        }
    }

    private Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"❌ Xato: {exception.Message}");
        return Task.CompletedTask;
    }
}
