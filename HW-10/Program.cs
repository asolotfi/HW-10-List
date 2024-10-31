using HW_10.DataBase;
using HW_10.Entities;
using HW_10.UserService;
using Newtonsoft.Json;

UserService userService = new UserService();
string directoryPath = @"c:\Hw-10";
string filePath = "UsersList.json";
string fullpath = Path.Combine(directoryPath, filePath);
try
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
        string jsonData = JsonConvert.SerializeObject(Storage.Users);
        File.WriteAllText(fullpath, jsonData);
        Console.WriteLine("Data saved to file successfully");
    }
}
catch (Exception)
{
    Console.WriteLine($"Data saved to file unsuccessfully");
}
while (true)
{
    Console.Clear();
    Console.WriteLine("Enter command for Example --> Register --username aso@ --password 123");
    Console.WriteLine("Enter command for Example --> login --username aso@ --password 123");
    Console.WriteLine("Enter command for Example --> changepassword --old 123 --new 1234");
    Console.WriteLine("Enter command for Example --> update --status  notavailable");
    Console.WriteLine("Enter command for Example --> search --username  as");
    Console.WriteLine("Enter command for Example --> logout");
    string command = Console.ReadLine();
    var parts = command.Split(' ');
    var action = "";
    var Parta = "";
    var partb = "";
    if (parts.Length > 0)
    {
        action = parts[0];
    }
    else
    {
        Console.WriteLine("Enter command");
    }
    switch (action.ToLower().Trim())
    {
        case "register":
            Parta = parts[2];
            partb = parts[4];
            if (parts[1] == "--username" && parts[3] == "--password")
            {
                User user = new User(Parta, partb);
                var results = userService.Register(user, partb);
                if (results.IsSucces)
                {
                    Console.WriteLine("register is successful");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("register is unsuccessfully");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Enter command correct for example Register --username aso@ --password 123");
                Console.ReadLine();
            }
            break;
        case "login":
            Parta = parts[2];
            partb = parts[4];
            if (parts[1] == "--username" && parts[3] == "--password")
            {
                User user = new User(Parta, partb);
                var result = userService.login(user, partb);
                if (result.IsSucces)
                {
                    Storage.Onlineuser.Status = " available";
                    Console.WriteLine("login is successful");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("USER IS NOT.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Enter command correct for example login --username aso@ --password 123");
                Console.ReadLine();
            }
            break;
        case "changepassword":
            if (Storage.Onlineuser != null)
            {
                Parta = parts[2];
                partb = parts[4];
                if (parts[1] == "--old" && parts[3] == "--new")
                {
                    var restitch = userService.ChangePassword(Parta, partb);
                    if (restitch.IsSucces)
                    {
                        Console.WriteLine("change password is successful");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Enter command correct for example changepassword --old 123 --new 1234");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("pleas login");
                Console.ReadLine();
            }
            break;
        case "update":
            if (Storage.Onlineuser != null)
            {
                partb = parts[3];
                if (parts[1] == "--status")
                {
                    var result = userService.ChangeStatus(partb);
                    if (result.IsSucces)
                    {
                        Console.WriteLine("update status is successful");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Enter command correct for example update --status  notavailable");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("pleas login");
                Console.ReadLine();
            }
            break;
        case "search":

            if (Storage.Onlineuser != null)
            {
                partb = parts[3];
                if (parts[1] == "--username")
                {
                    var results = userService.search(partb);
                    if (results.IsSucces)
                    {
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Enter command correct for example Example --> search --username  as");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("pleas login");
                Console.ReadLine();
            }
            break;
        case "logout":
            Storage.Onlineuser = null;
            break;
        default:
            Console.WriteLine("unknown");
            break;
    }
}
