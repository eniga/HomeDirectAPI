using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("propertydocuments")]
    public class PropertyDocuments
    {
        [Key]
        public int DocumentID { get; set; }
        public string UserID { get; set; }
        public string PropertyID { get; set; }
        public string DocumentFile { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentType { get; set; }
        public string DocumentStatus {get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedTimestamp { get; set; }
        public string UploadDate { get; set; }
        public string UploadDate2 { get; set; }
    }

    public class ListPropertyDocumentsResponse : Response
    {
        public List<PropertyDocuments> data { get; set; }
    }

    public class PropertyDocumentsResponse : Response
    {
        public PropertyDocuments data { get; set; }
    }
}
