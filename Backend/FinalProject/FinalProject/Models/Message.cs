using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Sender Name")]
        public string SenderName { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Sender Type")]
        public string SenderType { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Display(Name = "Reciever Name")]
        public string ReceiverName { get; set; }

        [Column(TypeName = "varchar"), StringLength(500), Display(Name = " Text")]
        public string Text { get; set; }
    }
}