using NavoiyTelefonBozorBot.Database;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NavoiyTelefonBozorBot.Bot;

public class AdminService
{
    private readonly ITelegramBotClient _botClient;
    private readonly AppDbContext _db;
    private readonly long _adminId = 123456789; // Admin Telegram ID

    public AdminService(ITelegramBotClient botClient, AppDbContext db)
    {
        _botClient = botClient;
        _db = db;
    }

    public async Task HandleAdminCommand(Message message)
    {
        if (message.Chat.Id != _adminId)
            return;

        if (message.Text == "/stats")
        {
            int userCount = _db.Users.Count();
            int postCount = _db.Announcements.Count();
            await _botClient.SendTextMessageAsync(message.Chat.Id,
                $"📊 Bot statistikasi:\n👥 Foydalanuvchilar: {userCount}\n📢 E’lonlar: {postCount}");
        }
    }
}
