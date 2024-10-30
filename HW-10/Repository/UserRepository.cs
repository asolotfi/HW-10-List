using HW_10.Cantract;
using HW_10.DataBase;
using HW_10.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Repository
{
    public class UserRepository : IUserRepository
    {
        string path = @"c:\Botkamp Sharif\Hw-10\UsersList.json";
        public Result AddUser(User userOutput)
        {
            
                var date = File.ReadAllText(path);
                var Users = JsonConvert.DeserializeObject<List<User>>(date);
                var user = Users.Find(U => U.UserName == userOutput.UserName);
                if (user == null)
                {
                    Users.Add(userOutput);
                    var resultF = JsonConvert.SerializeObject(Users);
                    File.WriteAllText(@"c:\Botkamp Sharif\Hw-10\UsersList.json", resultF);
                    return new Result(true);
                }
           
         
            return new Result(false);
        }



        public List<User> GetUsers()
        {
            var date = File.ReadAllText(path);
            var Users = JsonConvert.DeserializeObject<List<User>>(date);
            return Users;

        }

        public void Login(User user)
        {

            Storage.Onlineuser = user;

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
                    //Users.Add(user);
                    var resultF = JsonConvert.SerializeObject(Users);
                    File.WriteAllText(@"c:\Botkamp Sharif\Hw-10\UsersList.json", resultF);
                    return new Result(true, "change password is successfull");
                }
              
               
            }
            catch (Exception)
            {
                return new Result(true, "change password is unsuccessfull");
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
                if(user != null)
                {
                    user.Status= status;
                    var resultF = JsonConvert.SerializeObject(Users);
                    File.WriteAllText(@"c:\Botkamp Sharif\Hw-10\UsersList.json", resultF);
                    return new Result(true);
                }
                else
                {
                    return new Result(false);
                }
               
            }
            catch (Exception)
            {

                return new Result(false, "change password is unsuccessfull");
            }
           
        }
        public List<User> seartch(string username)
        {
            var date = File.ReadAllText(path);
            var Users = JsonConvert.DeserializeObject<List<User>>(date);
            var user = Users.FirstOrDefault(U => U.UserName.Substring(0,2) == username);
            List<User>  result= new List<User>();
            foreach (var usernam in Users)
            {
                int i = username.Count();
                if (usernam.UserName.Substring(0, i) == username)
                {
                    result.Add(usernam);
                }
            }
            return result;
        }
    }
}
