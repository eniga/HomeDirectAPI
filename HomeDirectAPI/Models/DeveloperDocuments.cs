using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("developerdocuments")]
    public class DeveloperDocuments
    {
        [Key]
        public int DocumentID { get; set; }
        public string UserID { get; set; }
        public string DocumentFile { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentType { get; set; }
        public string DocumentStatus { get; set; }
        public string UploadDate { get; set; }
        public string UploadDate2 { get; set; }
    }

    public class ListDeveloperDocumentsResponse : Response
    {
        public List<DeveloperDocuments> data { get; set; }
    }

    public class DeveloperDocumentsResponse : Response
    {
        public DeveloperDocuments data { get; set; }
    }
}
