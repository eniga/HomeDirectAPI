using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
