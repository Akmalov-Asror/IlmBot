using IlmBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botService = new TelegramService();
var usersService = new UsersService(botService);
var menuService = new MenuService(botService);
botService.GetUpdate((_, update, _) => Task.Run(() => GetUpdate(update)));

Console.ReadKey();

void GetUpdate(Update update)
{
    Telegram.Bot.Types.User From;
    string messageFromUser;
    if (update.Type == UpdateType.Message)
    {
        From = update.Message.From;
        messageFromUser = update.Message.Text;

    }
    else if (update.Type == UpdateType.CallbackQuery)
    {
        From = update.CallbackQuery.From;
        messageFromUser = update.CallbackQuery.Data;
        HandleCallBackData(From, messageFromUser);
        HandleOptions(From, messageFromUser);
        HandleOptions2(From, messageFromUser);
        HandleOptions3(From, messageFromUser);
        HandleOptions4(From, messageFromUser);
        SendRecitersAudio(From, messageFromUser);
        SectsOptions(From, messageFromUser);
        SectsMessage(From, messageFromUser);
    }
    else return;
    var user = usersService.AddUser(From);
    StepFilter(user, messageFromUser);
}
void StepFilter(IlmBot.Models.User user,string message)
{
    switch (user.Step)
    {
        case EUserStep.NewUser: menuService.SendMenu(user, message); break;
        case EUserStep.Menu: menuService.TextFilter(user, message); break;
        case EUserStep.GetRecitersRecording: break;
        case EUserStep.SahabahsLife: menuService.TextFilter(user,message); break;
        case EUserStep.SectsAbout: menuService.TextFilter(user, message); break;
        
    }
}

void HandleCallBackData(User user,string query)
{
    switch (query)
    {
        case "1.Abu Bakr As-Siddiq":menuService.SahabasLifeOptions(user);break;
        case "2.Umar ibn Al-Khattab": menuService.SahabasLifeOptions2(user); break;
        case "3.Uthman ibn Affan": menuService.SahabasLifeOptions3(user);break;
        case "4.Ali ibn Abi Talib": menuService.SahabasLifeOptions4(user);break;
    }
}

void HandleOptions(User user,string query)
{
    if (query == "1.Video")
    {
        var pathFile = "https://www.youtube.com/watch?v=HwBryUFF5yg";
        botService.SendMessage(user.Id, pathFile);
    }
    else if(query == "2.Book")
    {
        var pathFile1 = "https://www.alislam.org/library/books/Hazrat-Abu-Bakr-Siddiq.pdf";
        botService.SendDocuments(user.Id, pathFile1);
    }
}
void HandleOptions2(User user, string query1)
{
    if (query1 == "01.Video")
    {
        var pathFile2 = "https://www.youtube.com/watch?v=plXVAzTNnpo";
        botService.SendMessage(user.Id, pathFile2);
    }
    else if (query1 == "02.Book")
    {
        var pathFile3 = "https://ia801308.us.archive.org/27/items/UmarIbnAlkhattab-IslamicEnglishBook-/UmarIbnAlkhattab-IslamicEnglishBook-Alhamdulillah-library.blogspot.in.pdf";
        botService.SendDocuments(user.Id, pathFile3);
    }
}
void HandleOptions3(User user, string query1)
{
    if (query1 == "001.Video")
    {
        var pathFile2 = "https://www.youtube.com/watch?v=yIRfhzN7VnM";
        botService.SendMessage(user.Id, pathFile2);
    }
    else if (query1 == "002.Book")
    {
        var pathFile = "http://islamicbulletin.org/en/ebooks/companions/othman_ibn_affan_the_third_caliph.pdf";
        botService.SendDocuments(user.Id,pathFile);
    }
}
void HandleOptions4(User user, string query1)
{
    if (query1 == "0001.Video")
    {
        var pathFile2 = "https://www.youtube.com/watch?v=fn3hfVNCBMI";
        botService.SendMessage(user.Id, pathFile2);
    }
    else if (query1 == "0002.Book")
    {
        var pathFile3 = "https://ia902804.us.archive.org/5/items/learnislampdfenglishbookaliibnabitalibvolume1/learn%20islam%20pdf%20english%20book%20__%20ali-ibn-abi-talib-volume-1.pdf";
        botService.SendDocuments(user.Id, pathFile3);
    }
}
 void SendRecitersAudio(Telegram.Bot.Types.User user, string message)
{
    switch (message)
    {
        case "Idrees Abkar":
            var filepath = "https://server6.mp3quran.net/abkr/001.mp3";
            botService.SendAudio(user.Id, filepath,"1.Al - Fatihah");
            break;
        case "Mahmoud Khalil Al-Hussary":
            var filepath1 = "https://server13.mp3quran.net/husr/001.mp3";
            botService.SendAudio(user.Id, filepath1, "1.Al - Fatihah");
            break;
        case "Maher Al Muaqli":
            var filepath2 = "https://server12.mp3quran.net/maher/001.mp3";
            botService.SendAudio(user.Id, filepath2, "1.Al - Fatihah");
            break;
        case "Mishary Al Afasy":
            var filepath3 = "https://server8.mp3quran.net/afs/001.mp3";
            botService.SendAudio(user.Id, filepath3, "1.Al - Fatihah");
            break;
        case "Muhammad Siddiq Al Minshawi":
            var filepath4 = "https://server10.mp3quran.net/minsh/001.mp3";
            botService.SendAudio(user.Id, filepath4, "1.Al - Fatihah");
            break;
    }
}

void SectsOptions(User user, string query)
{
    switch (query)
    {
        case "Imam al - A'zam":menuService.SectsAboutOptions(user); break;
        case "Imam al - Sho'fein": menuService.SectsAboutOptions2(user); break;
        case "Imam al - Ahmad": menuService.SectsAboutOptions3(user); break;
        case "Imam al - Molik": menuService.SectsAboutOptions4(user); break;
    }
}

void SectsMessage(User user,string query11)
{
    if (query11 == "11.Video")
    {
        var File = "Tayyor emas";
        botService.SendMessage(user.Id, File);
    }
    else if (query11 == "12.Text")
    {
        var File1 = "Tayyor emas kuuuuuuu";
        botService.SendMessage(user.Id,File1);
    }
}
   


