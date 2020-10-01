using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class CoursesOfStudentRepository:Repository<CoursesOfStudent>, ICoursesOfStudent
    {
        public List<CoursesOfStudent> GetCourseByStudent(string StdName)
        {
            return this.context.CoursesOfStudents.Where(x => x.StudentName == StdName).ToList();
        }
    }
}