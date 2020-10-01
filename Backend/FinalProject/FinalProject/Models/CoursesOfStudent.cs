using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class CoursesOfStudent
    {
        [Key]
        public int COSId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Column(TypeName = "varchar"), StringLength(1000), Display(Name = "Student Name")]
        public string StudentName { get; set; }


        public int CourseId { get; set; }

        public int TeacherId { get; set; }
    }
}