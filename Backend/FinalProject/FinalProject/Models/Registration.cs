using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Registration
    {
        [Key]
        public int RegId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Student Name")]
        public string StudentName { get; set; }


        public double Fee { get; set; }

        public int SubjectId { get; set; }
    }
}