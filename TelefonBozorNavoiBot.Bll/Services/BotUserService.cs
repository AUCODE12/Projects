using Microsoft.EntityFrameworkCore;
using TelefonBozorNavoiBot.Dal;
using TelefonBozorNavoiBot.Dal.Entities;

namespace TelefonBozorNavoiBot.Bll.Services;

public class BotUserService : IBotUserService
{
    private readonly MainContext mainContext;

    public BotUserService(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task AddUserAsync(BotUser user)
    {
        var dbUser = await mainContext.Users.FirstOrDefaultAsync(x => x.TelegramUserId == user.TelegramUserId);

        if (dbUser != null)
        {
            Console.WriteLine($"User with id : {user.TelegramUserId} already exists");
            return;
        }

        try
        {
            await mainContext.Users.AddAsync(user);
            await mainContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<BotUser> GetBotUserAsync(long telegramUserId)
    {
        var botUser = await mainContext.Users.FirstOrDefaultAsync(u => u.TelegramUserId == telegramUserId);

        if (botUser == null)
        {
            Console.WriteLine($"User with telegram id is not fount : {telegramUserId}");
        }

        return botUser;
    }

    public async Task<long> GetBotUserIdByTelegramUserIdAsync(long telegramUserId)
    {
        var botUserId = await mainContext.Users
            .Where(u => u.TelegramUserId == telegramUserId)
            .Select(u => (long?)u.BotUserId)
            .FirstOrDefaultAsync();

        if (botUserId == null)
        {
            Console.WriteLine($"User with Telegram ID {telegramUserId} not found.");
        }

        return botUserId ?? 0;
    }

    public async Task UpdateUserAsync(BotUser user)
    {
        var dbUser = await mainContext.Users.FirstOrDefaultAsync(x => x.TelegramUserId == user.TelegramUserId);

        if (dbUser == null)
        {
            Console.WriteLine($"User with id {user.TelegramUserId} not found");
            return;
        }

        try
        {
            dbUser.PhoneNumber = user.PhoneNumber; // Telefon raqamini yangilash
            mainContext.Users.Update(dbUser);
            await mainContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user {user.TelegramUserId}: {ex.Message}");
        }
    }

}
