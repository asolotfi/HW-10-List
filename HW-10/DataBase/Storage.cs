using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_10.Entities;
using Newtonsoft.Json;

namespace HW_10.DataBase
{
    public static class Storage
    {
        public static User? Onlineuser { get; set; }
        public static List<User> Users = new List<User>();
        static Storage()
        {
            Users.Add(new User( "aso@", "123"));
            Users.Add(new User("roza@", "123"));
            Users.Add(new User("zahra@", "123"));
        }

    }  
}
