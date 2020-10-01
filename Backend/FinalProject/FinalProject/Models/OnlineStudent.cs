using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class OnlineStudent
    {
        [Key]
        public int StudentId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Column(TypeName = "varchar"), StringLength(15), Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Student Institute")]
        public string StdInstitute { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Address")]
        public string Address { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Image Path")]
        public string ImagePath { get; set; }
    }
}