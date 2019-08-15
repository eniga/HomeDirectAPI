using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }
        public int From { get; set; }
        public string FromName { get; set; }
        public int To { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public List<Attachments> attachments { get; set; }
    }

    public class ListMessagesResponse : Response
    {
        public List<Messages> messages { get; set; }
    }

    public class MessagesResponse : Response
    {
        public Messages message { get; set; }
    }
}
