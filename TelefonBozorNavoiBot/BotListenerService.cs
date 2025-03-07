using TelefonBozorNavoiBot.Bll.Services;
using TelefonBozorNavoiBot.Dal.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelefonBozorNavoiBot;

public class BotListenerService
{
    private static string botToken = "7644272652:AAHEBPvxfe0_ggcLAapDwvjEOPfAh6A7NY8";
    private TelegramBotClient botClient = new TelegramBotClient(botToken);
    private readonly IBotUserService botUserService;
    private readonly IAnnouncementService announcementService;

    public BotListenerService(IBotUserService botUserService, IAnnouncementService announcementService)
    {
        this.botUserService = botUserService;
        this.announcementService = announcementService;
    }

    public async Task StartBot()
    {
        botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync
            );

        Console.WriteLine("Bot is runing");

        Console.ReadKey();
    }

    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            var user = update.Message.Chat;
            var message = update.Message;
            var botUserId = await botUserService.GetBotUserIdByTelegramUserIdAsync(user.Id);
            var botUser = await botUserService.GetBotUserAsync(user.Id);

            // Agar foydalanuvchining telefon raqami allaqachon bor bo‘lsa, to‘g‘ridan-to‘g‘ri menyuni yuborish
            if (message.Text == "/start")
            {
                if (botUser != null && !string.IsNullOrEmpty(botUser.PhoneNumber))
                {
                    await SendStartMenu(bot, user.Id);
                    return;
                }

                var requestContactKeyboard = new ReplyKeyboardMarkup(new[]
                {
                    KeyboardButton.WithRequestContact("📱 Telefon raqamingizni yuboring")
                })
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };

                await bot.SendTextMessageAsync(
                    chatId: user.Id,
                    text: "🔹 Iltimos, botdan foydalanish uchun telefon raqamingizni yuboring!",
                    replyMarkup: requestContactKeyboard
                );

                return;
            }

            // Agar foydalanuvchi telefon raqamini jo‘natgan bo‘lsa
            if (message.Contact != null)
            {
                if (botUser == null)
                {
                    botUser = new BotUser()
                    {
                        TelegramUserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        PhoneNumber = message.Contact.PhoneNumber
                    };

                    await botUserService.AddUserAsync(botUser);
                }
                else
                {
                    botUser.PhoneNumber = message.Contact.PhoneNumber;
                    await botUserService.UpdateUserAsync(botUser);
                }

                await SendStartMenu(bot, user.Id);
            }

        }

        else if (update.Type == UpdateType.CallbackQuery)
        {
            var id1 = update.CallbackQuery.Id;
            var id2 = update.CallbackQuery.InlineMessageId;
            var id = update.CallbackQuery.From.Id;

            CallbackQuery res = update.CallbackQuery;

            var rep = update.CallbackQuery.Data;


            await bot.SendTextMessageAsync(id, $"your option : {update.CallbackQuery.Data}");
        }
    }

    private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);
    }

    private static async Task SendStartMenu(ITelegramBotClient botClient, long userId)
    {
        var inlineKeyboard = new InlineKeyboardMarkup(new[] {
            new []
            {
                InlineKeyboardButton.WithUrl("📌 1-kanal", "https://t.me/Navoiyda_bugun"),
                InlineKeyboardButton.WithUrl("📌 2-kanal", "https://t.me/sisharpcode")
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData("✅ Tasdiqlash", "check_subscription")
            }});

        string welcomeMessage = @"
            📱✨ *Assalomu alaykum!* 😊  
            *Navoiy Telefon Bozor* botiga xush kelibsiz!  

            🔹 Bu yerda siz **telefon sotish**, **sotib olish** va **bo‘lib to‘lash** imkoniyatlaridan foydalanishingiz mumkin.  

            ⚠️ Davom etishdan oldin, quyidagi kanallarga obuna bo‘lishingiz kerak:  
            📌 [1-kanal] 
            📌 [2-kanal] 

            ✅ Obuna bo‘lib bo‘lgach, *Tasdiqlash* tugmasini bosing!  
            ";

        await botClient.SendTextMessageAsync(userId, welcomeMessage, parseMode: ParseMode.Markdown, replyMarkup: inlineKeyboard);
    }
}
