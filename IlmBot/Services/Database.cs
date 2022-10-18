
using IlmBot.Models;
using IlmBot.Services;
namespace IlmBot.Database;

public class Database
{
    private const string UsersJsonPath = "Data/users.json";
    private const string jsonPath = "";
    private static UserDatabase _userDatabase;
    public static UserDatabase UsersDb
    {
        get
        {
            if (_userDatabase == null)
            {
                _userDatabase = new UserDatabase(ReadJsonFile());
            }
            return _userDatabase;
        }
    }
    public static List<User> ReadJsonFile()
    {
        if (!File.Exists(UsersJsonPath)) return new List<User>();
        var jsonString = File.ReadAllText(UsersJsonPath);
        try
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(jsonString);
        }
        catch
        {
            Console.WriteLine("Cannot Convert !!!");
            return new List<User>();
        }

}

}
