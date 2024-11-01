using Dapper;
using HW_10.Configuration;
using HW_10.Contract;
using HW_10.Entities;
using HW_10.Repository.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Repository
{
    public class UserRepositoryDatabase : IUserRepositoryData
    {
        public Result AddUserSql(Entities.User user)
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.configurationstring))
            {
                db.Execute(UserQueries.create, new {user.UserName,user.Password,user.Status  });
            }      
                return new Result(true);           
        }
        public Entities.User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.configurationstring))
            {
                return db.QueryFirstOrDefault<Entities.User>(UserQueries.GetId,new{ Id = id});
            }          
        }
        public void Update(string status)
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.configurationstring))
            {
                db.Execute(UserQueries.Update, new { status=status});
            }
        }
        public void changePassword( string oldpassword,string newpassword)
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.configurationstring))
            {
                db.Execute(UserQueries.ChangePassword, new { password = newpassword });
            }
        }
        Entities.User IUserRepositoryData.GetAll()
        {
            throw new NotImplementedException();
        }
        public List<Entities.User> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Configuration.Configuration.configurationstring))
            {
                return db.Query<Entities.User>(UserQueries.GetAll).ToList();
            }
        }







        //search //////
    }
}
