using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("messages")]
    public class Messages
    {
        [Key]
        public long ID { get; set; }
        public string ThreadID { get; set; }
        public string SenderID { get; set; }
        public string RecipientID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime? MsgDate { get; set; }
        public DateTime? MsgDate2 { get; set; }
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
