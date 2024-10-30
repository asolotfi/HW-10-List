using HW_10.DataBase;
using HW_10.Entities;
using HW_10.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.UserService
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public Result Register(User user, string password)
        {
            var resultch = user.checkPassword(password);
            if (resultch.IsSucces)
            {
                var result = userRepository.AddUser(user);
                if (result.IsSucces)
                {
                    return new Result(true);
                }
                else
                {
                    return new Result(false);
                }
            }
            return new Result(false);

        }

        public Result login(User userO, string password)

        {
            try
            {
                var users = userRepository.GetUsers();
                foreach (var user in users)
                {
                    if (user.UserName == userO.UserName)
                    {
                        Storage.Onlineuser = userO;
                        var res = user.checkPassword(password);
                       
                        return new Result(true, "login is successfull");
                    }
                }
            }
            catch
            {
                return new Result(false, "user not found");
            }

            return new Result(false);
        }

        public Result ChhangePassword(string newpass, string oldpass)
        {
            var result = userRepository.ChangePassword(newpass, oldpass);
            if (result.IsSucces)
            {
               
                return new Result(true,"change password is successfull");
            }
            else
            {
                return new Result(true, "change password is unsuccessfull");
            }
        }
        public Result ChangeStatus(string status)
        {
            var result = userRepository.ChangeStatus(status);
            if (result.IsSucces)
            {
                
                    var users = userRepository.GetUsers();
                    foreach (var user in users)
                    {
                        if (user.UserName == Storage.Onlineuser.UserName)
                        {
                            Storage.Onlineuser.Status = status;

                            return new Result(true, "changestatus is successfull");
                        }
                    }
            
            }
          
                return new Result(true, "change status is unsuccessfull");
           
           
        }
        public Result seartch(string username)
        {
            var result = userRepository.seartch(username);
            if (result.Count>0)
            {foreach(User user in result)
                {
                    Console.WriteLine($"{user.UserName} | Status:{user.Status}");
                }             
            }
          
            return new Result(true, "change status is unsuccessfull");
        }
    }
}
