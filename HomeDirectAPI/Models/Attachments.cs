using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("attachments")]
    public class Attachments
    {
        [Key]
        public int AttachmentID { get; set; }
        public int MessageID { get; set; }
        public string FileName { get; set; }
    }
}
