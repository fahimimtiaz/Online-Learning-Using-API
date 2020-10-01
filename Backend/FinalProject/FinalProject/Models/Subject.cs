using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Column(TypeName = "varchar"), StringLength(1000), Display(Name = "Description")]
        public string Description { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "SubjectType")]
        public string SubjectType { get; set; }

        public double Price { get; set; }

        public int StudentCount { get; set; }

        public int TeacherId { get; set; }
    }
}