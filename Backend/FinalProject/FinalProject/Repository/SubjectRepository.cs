using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public Subject GetSubDetaileById(int id)
        {
            return this.context.Subjects.Where(x => x.SubjectId == id).FirstOrDefault();
        }
    }
}