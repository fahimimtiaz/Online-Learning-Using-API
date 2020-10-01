using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class MessageRepository: Repository<Message>
    {
        public List<Message> GetMessagesByName(string name)
        {
            return this.context.Messages.Where(x => x.ReceiverName == name || x.SenderName==name).ToList();
        }

        public string getSenderTypeByName(string sename)
        {
            var seType = this.context.Users.Where(p => p.UserName == sename).FirstOrDefault();

            return seType.UserType;
        }
    }
}