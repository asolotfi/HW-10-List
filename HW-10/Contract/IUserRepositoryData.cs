using HW_10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Contract
{
   public interface IUserRepositoryData
    {
        Result AddUserSql(User user);
        Entities.User Get(int id);
        Entities.User GetAll();
        void Update(string status);
        void changePassword(string oldpassword, string newpassword);
    }
}
