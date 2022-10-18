using IlmBot.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace IlmBot.Services;
public class MenuService
{
    private readonly TelegramService _telegramService;
    public MenuService(TelegramService telegramService)
    {
        _telegramService = telegramService;
    }
    public void SendMenu(User user, string message)
    {
        var Buttons = new List<string>() { "📖Quran Pdf", "🎧Litsen to Quran recitation", "The Lives of the Sahabah", "About the four sects" };
        user.SetStep(EUserStep.Menu);
        _telegramService.SendMessage(user.ChatId, "Choose menu",
        _telegramService.GetKeyboardButtons(Buttons));
    }
    public void TextFilter(User user, string message)
    {
        switch (message)
        {
            case "📖Quran Pdf": SendQuranPdf(user); break;
            case "🎧Litsen to Quran recitation": SendRecitersMenu(user);  break;
            case "The Lives of the Sahabah": SendSahabahsLife(user); break;
            case "About the four sects": SectsMenu(user); break;
        }
    }
    public void SendQuranPdf(User user)
    {
        var filePath = "https://propakistani.pk/wp-content/uploads/2008/09/quraan-majeed.pdf";
        _telegramService.SendDocuments(user.ChatId, filePath);
    }

    public void SendSahabahsLife(User user)
    {
        user.SetStep(EUserStep.SahabahsLife);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
    {
            new[]
            {
            InlineKeyboardButton.WithCallbackData(text:"1.Abu Bakr As-Siddiq",
            callbackData:"1.Abu Bakr As-Siddiq"),
            InlineKeyboardButton.WithCallbackData(text:"2.Umar ibn Al-Khattab",
            callbackData:"2.Umar ibn Al-Khattab"),
            },
            new[]
            {
            InlineKeyboardButton.WithCallbackData(text:"3.Uthman ibn Affan",
            callbackData:"3.Uthman ibn Affan"),
            InlineKeyboardButton.WithCallbackData(text:"4.Ali ibn Abi Talib",
            callbackData:"4.Ali ibn Abi Talib"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"5.The Lives of the Sahabah book",
                callbackData:"5.The Lives of the Sahabah book"),
            },
    });
        _telegramService.SendMessage(user.ChatId, "Please choose the Sahabah ⬇️", inlineKeyboard);

    }
    public void SahabasLifeOptions(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"1.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Book",
                callbackData:"2.Book"),
            },

        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);


    }
    public void SahabasLifeOptions2(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"01.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Book",
                callbackData:"02.Book"),
            },

        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);
    }
    public void SahabasLifeOptions3(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"001.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Book",
                callbackData:"002.Book"),
            },

        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);
    }
    public void SahabasLifeOptions4(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"0001.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Book",
                callbackData:"0002.Book"),
            },

        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);
    }

    public void SectsMenu( User user)
    {
        user.SetStep(EUserStep.SectsAbout);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"Imam al - A'zam",
                callbackData:"Imam al - A'zam"),
                InlineKeyboardButton.WithCallbackData(text:"Imam al - Sho'fein",
                callbackData:"Imam al - Sho'fein"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"Imam al - Ahmad",
                callbackData:"Imam al - Ahmad"),
                InlineKeyboardButton.WithCallbackData(text:"Imam al - Molik",
                callbackData:"Imam al - Molik"),
            }
        });
        _telegramService.SendMessage(user.ChatId, "Choose a Button",inlineKeyboard);
    }
    public void SendRecitersMenu(User user)
    {
        user.SetStep(EUserStep.GetRecitersRecording);
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
        // first row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "1️⃣ Idrees Abkar", callbackData: "Idrees Abkar"),
            InlineKeyboardButton.WithCallbackData(text: "2️⃣ Mahmoud Khalil Al-Hussary",
            callbackData: "Mahmoud Khalil Al-Hussary"),
        },
        // second row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "3️⃣ Maher Al Muaqli", callbackData: "Maher Al Muaqli"),
            InlineKeyboardButton.WithCallbackData(text: "4️⃣ Mishary Al Afasy", callbackData: "Mishary Al Afasy"),
        },
        //third row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "5️⃣Muhammad Siddiq Al Minshawi",
            callbackData: "Muhammad Siddiq Al Minshawi"),
        },
        });
        _telegramService.SendMessage(user.ChatId, "Please choose the reicter👳🏻‍♂️", inlineKeyboard);
    }

    public void SectsAboutOptions(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"11.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Text",
                callbackData:"12.Text"),
            },
        });
        _telegramService.SendMessage(user.Id,"Choose from menu",inlineKeyboard);
    }
    public void SectsAboutOptions2(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"21.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Text",
                callbackData:"22.Text"),
            },
        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);
    }
    public void SectsAboutOptions3(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"31.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Text",
                callbackData:"32.Text"),
            },
        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);
    }
    public void SectsAboutOptions4(Telegram.Bot.Types.User user)
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"1.Video",
                callbackData:"41.Video"),
                InlineKeyboardButton.WithCallbackData(text:"2.Text",
                callbackData:"42.Text"),
            },
        });
        _telegramService.SendMessage(user.Id, "Choose from menu", inlineKeyboard);
    }
}