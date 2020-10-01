using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class TeacherFinancialRepository : Repository<TeacherFinancial>
    {
        public List<TeacherFinancial> getTeacherFinancials()
        {
            return this.context.TeacherFinancials.ToList();
        }
    }
}