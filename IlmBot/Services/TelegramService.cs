using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace IlmBot.Services;

public class TelegramService
{
    private readonly string Token = "5433526188:AAF33zkJxfaErw0vqZAKq4WtB67F5gvelxM";
    private TelegramBotClient Bot;
    public TelegramService()
    {
        Bot = new TelegramBotClient(Token);
    }
    public void GetUpdate(Func<ITelegramBotClient, Update, CancellationToken, Task> update)
    {
        Bot.StartReceiving(
            updateHandler: update,
            errorHandler: (_, ex, _) =>
            {
                Console.WriteLine(ex);
                return Task.CompletedTask;
            },
            new ReceiverOptions()
            {
                ThrowPendingUpdates = true,
            }
            );
    }

    public ReplyKeyboardMarkup GetKeyboardButtons(List<string> buttons)
    {
        KeyboardButton[][] buttonsText = new KeyboardButton[buttons.Count][];
        for (int i = 0; i < buttons.Count; i++)
        {
            buttonsText[i] = new KeyboardButton[] { new KeyboardButton(buttons[i]) };
        }
        return new ReplyKeyboardMarkup(buttonsText) { ResizeKeyboard = true };
    }

    public void SendMessage(long chatId, string message, IReplyMarkup reply = null)
    {
        Bot.SendTextMessageAsync(chatId,message,replyMarkup:reply);
    }
    public void SendAudio(long chatId,string path,string caption = null)
    {
        Bot.SendAudioAsync(chatId, path,caption);
    }
    public void SendDocuments(long chatId,string path)
    {
        Bot.SendDocumentAsync(chatId, path,caption: "Me Allah be pleased with you");
    }
    public void SendVideo(long chatId,string path)
    {
        Bot.SendVideoAsync(chatId ,path);
        
    }
    public void SendPhoto(long chatId,string path)
    {
        Bot.SendPhotoAsync(chatId ,path,caption: "Me Allah be pleased with you");
    }
    
}
