using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class MyMaterial
    {
        [Key]
        public int MaterialId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Material Name")]
        public string MaterialName { get; set; }

        [Column(TypeName = "varchar"), StringLength(100), Display(Name = "Material Link")]
        public string MaterialLink { get; set; }

        public int SubjectId { get; set; }
    }
}