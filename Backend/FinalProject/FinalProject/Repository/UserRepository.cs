using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public List<User> getUserInfoByName(string name)
        {
            return this.context.Users.Where(x => x.UserName == name).ToList();
        }
    }
}