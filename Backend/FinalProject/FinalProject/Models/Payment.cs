using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Payment
    {
        [Key]
        public int PId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Student Name")]
        public string StudentName { get; set; }

        public double Amount { get; set; }
    }
}