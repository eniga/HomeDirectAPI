using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    [Table("mortgageloandocs")]
    public class MorgageLoanDocs
    {
        [Key]
        public int LoanDocsID { get; set; }
        public int MortgageLoanID { get; set; }
        public string DocsDesc { get; set; }
        public string DocsLink { get; set; }
        public string DocsName { get; set; }
        public string Docpath { get; set; }
        public string DocsUrl { get; set; }
        public string Docsstatus { get; set; }
        public string attachment { get; set; }
    }

    public class ListMortgageDocResponse : Response
    {
        public List<MorgageLoanDocs> MortgageDocs { get; set; }
    }

    public class MortgageDocResponse : Response
    {
        public MorgageLoanDocs MorgageLoanDoc { get; set; }
    }

    public class UpdateMortgageLoanDocs
    {
        public int LoanDocsID { get; set; }
        public string Docsstatus { get; set; }
    }
}
