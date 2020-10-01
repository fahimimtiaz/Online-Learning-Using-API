using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class LoginRepository : Repository<User>, ILoginRepository
    {
        public string checkUserType(string UserName, string Password)
        {
            var type = this.context.Users.Where(p => p.UserName == UserName && p.Password == Password).FirstOrDefault();
            if (type != null)
            {
                return type.UserType;
            }
            else
            {
                return "invalid";
            }
        }

        public string ValidateStudent(string UserName, string Password)
        {
            var u = this.context.Users.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
            if(u != null)
            {
                return u.UserName;
            }
            else
            {
                return "invalid";
            }
        }
    }
}