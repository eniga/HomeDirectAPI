using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("thread")]
    public class Thread
    {
        [Key]
        public long ID { get; set; }
        public string ThreadID { get; set; }
        public string SenderID { get; set; }
        public string RecipientID { get; set; }
        public string MsgRef { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string MsgStatus { get; set; }
        public DateTime? MsgDate { get; set; }
        public DateTime? MsgDate2 { get; set; }
    }

    public class ListThreadResponse : Response
    {
        public List<Thread> data { get; set; }
    }

    public class ThreadResponse : Response
    {
        public Thread data { get; set; }
    }
}
