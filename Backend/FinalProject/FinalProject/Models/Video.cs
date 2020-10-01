using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Video Name")]
        public string VideoName { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Video Description")]
        public string VideoDescription { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Video Path")]
        public string VideoPath { get; set; }



        public int SubjectId { get; set; }
    }
}