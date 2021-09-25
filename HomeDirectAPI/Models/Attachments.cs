using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("attachments")]
    public class Attachments
    {
        [Key]
        public long AttachmentID { get; set; }
        public long MessageID { get; set; }
        public string FileName { get; set; }
    }
}
