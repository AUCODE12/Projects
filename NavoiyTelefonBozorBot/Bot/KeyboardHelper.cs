using Telegram.Bot.Types.ReplyMarkups;

namespace NavoiyTelefonBozorBot.Bot;

public class KeyboardHelper
{
    public static ReplyKeyboardMarkup LanguageButtons()
    {
        return new ReplyKeyboardMarkup(new[]
        {
                new KeyboardButton[] { "🇺🇿 O‘zbekcha", "🇷🇺 Русский", "🇬🇧 English" }
            })
        {
            ResizeKeyboard = true
        };
    }

    public static ReplyKeyboardMarkup MainMenuButtons()
    {
        return new ReplyKeyboardMarkup(new[]
        {
                new KeyboardButton[] { "📱 Telefon sotib olish", "📢 E’lon berish" },
                new KeyboardButton[] { "💰 Bo‘lib to‘lashga olish", "⚙ Tilni o‘zgartirish" }
            })
        {
            ResizeKeyboard = true
        };
    }
}
