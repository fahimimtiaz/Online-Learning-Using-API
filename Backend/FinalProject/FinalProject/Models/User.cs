using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "User Name")]
        public string UserName { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Password")]
        public string Password { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "User Type")]
        public string UserType { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Status")]
        public string Status { get; set; }
    }
}