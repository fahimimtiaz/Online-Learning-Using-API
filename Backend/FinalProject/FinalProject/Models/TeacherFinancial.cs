using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class TeacherFinancial
    {

        [Key]
        public int FId { get; set; }


        public double Salary { get; set; }

        public int TeacherId { get; set; }
    }
}