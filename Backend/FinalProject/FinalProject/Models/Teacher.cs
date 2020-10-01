using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Address")]
        public string Address { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Institute")]
        public string Institute { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "User Name")]
        public string UserName { get; set; }

        public double Salary { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Image Path")]
        public string ImagePath { get; set; }
    }
}