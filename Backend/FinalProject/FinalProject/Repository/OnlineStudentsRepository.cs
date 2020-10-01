using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class OnlineStudentsRepository : Repository<OnlineStudent>, IOnlineStudentRepository
    {
        public OnlineStudent getInfoByName(string name)
        {
            return this.context.OnlineStudents.Where(x => x.StudentName == name).FirstOrDefault();
        }

        public List<OnlineStudent> GetOnlineStudentsHey(string n)
        {
            return this.context.OnlineStudents.Where(x => x.StudentName == n).ToList();
        }
    }
}