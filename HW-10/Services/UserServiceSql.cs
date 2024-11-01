using HW_10.DataBase;
using HW_10.Entities;
using HW_10.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Services
{
    public class UserServiceSql
    {
        UserRepositoryDatabase userRepositoryDatabase = new UserRepositoryDatabase();
        public Result Register(User user, string password)
        {
            var results = user.checkPassword(password);
            if (results.IsSucces)
            {
                var resultSql = userRepositoryDatabase.AddUserSql(user);
                if (resultSql.IsSucces)
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
                var userSql = userRepositoryDatabase.GetAll();
                foreach (var user in userSql)
                {
                    if (user.UserName == userO.UserName)
                    {
                        var res = user.checkPassword(password);
                        if (res.IsSucces)
                        {
                            Storage.Onlineuser = userO;
                            return new Result(true, "login is successful");
                        }
                    }
                }
            }
            catch
            {
                return new Result(false, "user not found");
            }
            return new Result(false);
        }
        public bool ChangePassword(string newpass, string oldpass)
        {

            userRepositoryDatabase.changePassword(newpass, oldpass);
            return true;
        }
        public Result ChangeStatus(string status)
        {
            userRepositoryDatabase.Update(status);
            if (result.IsSucces)
            {
                return new Result(true, "change status is successful");
            }
            return new Result(true, "change status is unsuccessful");
        }
        public Result search(string username)
        {
            //var result = userRepository.search(username);
            //if (result.Count > 0)
            //{
            //    foreach (User user in result)
            //    {
            //        Console.WriteLine($"{user.UserName} | Status:{user.Status}");
            //    }
            //    return new Result(true);
            //}
            return new Result(false, " no user found");
        }
    }
}
