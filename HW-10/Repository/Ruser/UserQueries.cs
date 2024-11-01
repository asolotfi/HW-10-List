using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Repository.User
{
    public static class UserQueries
    {
        public static string create = "insert into Users(userName,Password,Status) Values(@userName,@Password,@Status)";
        public static string GetId = "SELECT * FROM * Users WHERE Id=@Id";
        public static string GetAll = "SELECT * FROM Users ";
        public static string ChangePassword = "UPDATE Users SET  Password=@Password WHERE Id=@Id";
        public static string Update = "UPDATE Users SET  Status=@Status WHERE Id=@Id";
    }
    
}
