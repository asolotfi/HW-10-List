using HW_10;
using HW_10.DataBase;
using HW_10.Entities;
using HW_10.Repository;
using HW_10.UserService;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Security.AccessControl;
using System.Xml;

UserService userService = new UserService();

// everyone Folder
string directoryPath = @"c:\Botkamp Sharif\Hw-10";
string filePath = "UsersList.json";
string fullpath = Path.Combine(directoryPath, filePath);
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);

}
string jsonData = JsonConvert.SerializeObject(Storage.Users);
try
{
    File.WriteAllText(fullpath, jsonData);
    Console.WriteLine("Data saved to file sucssecfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Data saved to file unsucssecfully");
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
            User user = new User(Parta, partb);
            var results = userService.Register(user, partb);
            if (results.IsSucces)
            {
                Console.WriteLine("register is successfull");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("register is unsuccessfull");
                Console.ReadLine();
            }
            break;
        case "login":
            Parta = parts[2];
            partb = parts[4];
            User userl = new User(Parta, partb);
            var resultl = userService.login(userl, partb);
            if (resultl.IsSucces)
            {
                Storage.Onlineuser.Status = " available";
                Console.WriteLine("login is successfull");
                Console.ReadLine();
            }
            else
            {
                Console.Write("register failed! username already exists.");
                Console.ReadLine();
            }
            break;
        case "changepassword":
            if (Storage.Onlineuser != null)
            {
                Parta = parts[2];
                partb = parts[4];
                var resultch = userService.ChhangePassword(Parta, partb);
                if (resultch.IsSucces)
                {
                    Console.WriteLine("change password is successfull");
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
                var resultch = userService.ChangeStatus(partb);
                if (resultch.IsSucces)
                {
                    Console.WriteLine("update status is successfull");
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
            try
            {
                if (Storage.Onlineuser != null)
                {
                    partb = parts[3];
                    var resultch = userService.seartch(partb);
                    if (resultch.IsSucces)
                    {
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("pleas login");
                    Console.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("pleas login");
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
