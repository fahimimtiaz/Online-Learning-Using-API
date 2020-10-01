using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public List<Teacher> GetTeacherByThread(string uName)
        {
            return this.context.Teachers.Where(x => x.UserName == uName).ToList();

        }

        public Teacher GetTeacher(string uName)
        {
            var tech = this.context.Teachers.Where(x => x.UserName == uName).FirstOrDefault();
            return tech;
        }

        public int GetTeacherId(string UName)
        {
            var type = this.context.Teachers.Where(p => p.UserName == UName).FirstOrDefault();
            return type.TeacherId;

        }

        public List<Subject> GetSubjectByTeacher(int id)
        {
            return this.context.Subjects.Where(x => x.TeacherId == id).ToList();

        }

        public List<Teacher> GetTeacherById(int id)
        {
            return this.context.Teachers.Where(x => x.TeacherId == id).ToList();

        }


    }
}