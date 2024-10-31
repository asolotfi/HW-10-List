using HW_10.Cantract;
using HW_10.DataBase;
using HW_10.Entities;
using Newtonsoft.Json;

namespace HW_10.Repository
{
    public class UserRepository : IUserRepository
    {
        string path = @"c:\Hw-10\UsersList.json";
        public Result AddUser(User userOutput)
        {
            var date = File.ReadAllText(path);
            var Users = JsonConvert.DeserializeObject<List<User>>(date);
            var user = Users.Find(U => U.UserName == userOutput.UserName);
            if (user == null)
            {
                Users.Add(userOutput);
                var resultF = JsonConvert.SerializeObject(Users);
                File.WriteAllText(path, resultF);
                return new Result(true);
            }
            else
            {
                return new Result(false);
            }
        }

        public List<User> GetUsers()
        {
            var date = File.ReadAllText(path);
            var Users = JsonConvert.DeserializeObject<List<User>>(date);
            return Users;
        }

        public Result ChangePassword(string oldpass, string newpass)
        {
            try
            {
                var date = File.ReadAllText(path);
                var Users = JsonConvert.DeserializeObject<List<User>>(date);
                var user = Users.Find(U => U.UserName == Storage.Onlineuser.UserName && U.Password == oldpass);
                if (user != null)
                {
                    user.Password = newpass;
                    var resultF = JsonConvert.SerializeObject(Users);
                    File.WriteAllText(path, resultF);
                    return new Result(true, "change password is successful");
                }
            }
            catch (Exception)
            {
                return new Result(true, "change password is unsuccessful");
            }
            return new Result(false);
        }
        public Result ChangeStatus(string status)
        {
            try
            {
                var date = File.ReadAllText(path);
                var Users = JsonConvert.DeserializeObject<List<User>>(date);
                var user = Users.FirstOrDefault(U => U.UserName == Storage.Onlineuser.UserName);
                if (user != null)
                {
                    user.Status = status;
                    var resultF = JsonConvert.SerializeObject(Users);
                    File.WriteAllText(path, resultF);
                    return new Result(true);
                }
                else
                {
                    return new Result(false);
                }
            }
            catch (Exception)
            {
                return new Result(false, "change password is unsuccessful");
            }
        }
        public List<User> search(string username)
        {
            var date = File.ReadAllText(path);
            var Users = JsonConvert.DeserializeObject<List<User>>(date);

            List<User> result = new List<User>();
            foreach (var usernam in Users)
            {
                int i = username.Count();
                if (usernam.UserName.Contains(username))
                {
                    result.Add(usernam);
                }
            }
            return result;
        }
    }
}
