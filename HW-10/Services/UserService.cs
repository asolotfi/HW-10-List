using HW_10.DataBase;
using HW_10.Entities;
using HW_10.Repository;

namespace HW_10.UserService
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
       
        public Result Register(User user, string password)
        {
            var results = user.checkPassword(password);
            if (results.IsSucces)
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
                        var res = user.checkPassword(password);
                        if (res.IsSucces)
                        {
                            Storage.Onlineuser = userO;
                            return new Result(true, "login is successfull");
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

        public Result ChangePassword(string newpass, string oldpass)
        {
            var result = userRepository.ChangePassword(newpass, oldpass);
            if (result.IsSucces)
            {
                return new Result(true, "change password is successful");
            }
            else
            {
                return new Result(true, "change password is unsuccessful");
            }
        }
        public Result ChangeStatus(string status)
        {
            var result = userRepository.ChangeStatus(status);
            if (result.IsSucces)
            {
                return new Result(true, "change status is successful");
            }
            return new Result(true, "change status is unsuccessful");
        }
        public Result search(string username)
        {
            var result = userRepository.search(username);
            if (result.Count > 0)
            {
                foreach (User user in result)
                {
                    Console.WriteLine($"{user.UserName} | Status:{user.Status}");
                }
                return new Result(true);
            }
            return new Result(false, " no user found");
        }
    }
}
