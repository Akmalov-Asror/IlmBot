using IlmBot.Models;

namespace IlmBot.Services;

public class UsersService
{
    public readonly TelegramService _telegramBotService;
    public UsersService(TelegramService telegramBotService)
    {
        _telegramBotService = telegramBotService;
    }
    public User AddUser(Telegram.Bot.Types.User user)
    {
        var name = string.IsNullOrEmpty(user.Username) ? user.FirstName : user.Username;
        return Database.Database.UsersDb.AddUser(user.Id, name);
    }
}