using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("documents")]
    public class Documents
    {
        [Key]
        public long DocumentID { get; set; }
        public string LoanID { get; set; }
        public string UserID { get; set; }
        public string PropertyID { get; set; }
        public string File { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentStatus { get; set; }
        public DateTime? UploadDate { get; set; }
        public string UploadDate2 { get; set; }
    }
}
