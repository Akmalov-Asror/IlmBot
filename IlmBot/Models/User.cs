using IlmBot.Database;

namespace IlmBot.Models;

public class User
{
    public long ChatId { get; set; }  
    public string Name { get; set; }
    public EUserStep Step { get; set; }

    public User(long chatId, string name, EUserStep step)
    {
        ChatId = chatId;
        Name = name;
        Step = step;
    }

    public User(long chatId,string name)
    {
        ChatId = chatId;
        Name = name;
    }
    public void SetStep(EUserStep step)
    {
        Step = step;
    }
}