using NavoiyTelefonBozorBot.Database;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NavoiyTelefonBozorBot.Bot;

public class CommandHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly AppDbContext _db;

    public CommandHandler(ITelegramBotClient botClient, AppDbContext db)
    {
        _botClient = botClient;
        _db = db;
    }

    public async Task HandleUpdateAsync(Update update)
    {
        if (update.Message == null) return;

        var message = update.Message;
        var chatId = message.Chat.Id;

        if (message.Text == "/start")
        {
            var user = _db.Users.FirstOrDefault(u => u.TelegramId == chatId);
            if (user == null)
            {
                var newUser = new UserTg { TelegramId = chatId, FullName = message.Chat.FirstName };
                _db.Users.Add(newUser);
                _db.SaveChanges();
                await _botClient.SendTextMessageAsync(chatId, "✅ Ro‘yxatdan o‘tdingiz!", replyMarkup: KeyboardHelper.LanguageButtons());
            }
            else
            {
                await _botClient.SendTextMessageAsync(chatId, "Siz allaqachon ro‘yxatdan o‘tgan ekansiz.");
            }
        }
    }
}
