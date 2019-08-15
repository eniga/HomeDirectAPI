using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    [Table("MortgageLoanDocs")]
    public class MorgageLoanDocs
    {
        [Key]
        public int LoanDocsID { get; set; }
        public int MortgageLoanID { get; set; }

        public string DocsName { get; set; }

        public string DocsDesc { get; set; }

        public string DocsLink { get; set; }
        public IFormFile attachment { get; set; }
        // public HttpRequest Request { get; set; }
    }

    public class ListMortgageDocResponse : Response
    {
        public List<MorgageLoanDocs> MortgageDocs { get; set; }
    }

    public class MortgageDocResponse : Response
    {
        public MorgageLoanDocs MorgageLoanDoc { get; set; }
    }
}
