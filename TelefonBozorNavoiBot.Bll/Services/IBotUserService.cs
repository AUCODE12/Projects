using TelefonBozorNavoiBot.Dal.Entities;

namespace TelefonBozorNavoiBot.Bll.Services;

public interface IBotUserService
{
    Task AddUserAsync(BotUser user);
    Task<long> GetBotUserIdByTelegramUserIdAsync(long telegramUserId);
    Task<BotUser> GetBotUserAsync(long telegramUserId);
    Task UpdateUserAsync(BotUser user);
}