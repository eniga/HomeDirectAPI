using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Attachments")]
    public class Attachments
    {
        [Key]
        public int AttachmentID { get; set; }
        public int MessageID { get; set; }
        public string FileName { get; set; }
    }
}
