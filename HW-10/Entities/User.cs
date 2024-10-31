using HW_10.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Entities
{
    public class User
    {
        public User(string userName, string password)
        {
            Id = GetId();
            UserName = userName;
            Password = password;
            Status = "available";
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }


        public int GetId()
        {
            int x = 0;
            x = Storage.Users.Count();
            x++;
            return x;
        }
        public Result checkPassword(string pass)
        {
            if (Password == pass)
                return new Result(true, null);
            else
                return new Result(false, "password Is Incorrect.");
        }

    }
}
