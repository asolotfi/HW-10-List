using HW_10.Entities;
using HW_10.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Cantract
{
    public interface IUserRepository
    {
        Result AddUser(User user);
        List<User> GetUsers();
        Result ChangePassword(string newpass, string oldpass);
         Result ChangeStatus(string status);
        List<User> seartch(string username);
    }
}
