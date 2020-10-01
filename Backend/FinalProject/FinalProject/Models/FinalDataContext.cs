using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class FinalDataContext:DbContext
    {
        public FinalDataContext()
        {
           //Database.SetInitializer<FinalDataContext>(new DropCreateDatabaseIfModelChanges<FinalDataContext>());
        }
        virtual public DbSet<Teacher> Teachers { get; set; }
        virtual public DbSet<User> Users { get; set; }

        virtual public DbSet<Subject> Subjects { get; set; }
        virtual public DbSet<CoursesOfStudent> CoursesOfStudents { get; set; }
        virtual public DbSet<Message> Messages { get; set; }

        virtual public DbSet<MyMaterial> MyMaterials { get; set; }

        virtual public DbSet<OnlineStudent> OnlineStudents { get; set; }
        virtual public DbSet<Payment> Payments { get; set; }

        virtual public DbSet<Registration> Registrations { get; set; }

        virtual public DbSet<TeacherFinancial> TeacherFinancials { get; set; }
        virtual public DbSet<Video> Videos { get; set; }

    }
}