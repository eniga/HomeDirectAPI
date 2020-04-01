using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    public class MortgageLoanViewModel
    {
       // [Key]
        public int LoanDocsID { get; set; }
        public string MortgageLoanID { get; set; }

        public string DocsName { get; set; }

        public string DocsDesc { get; set; }
        public string DocsStatus { get; set; }

        public string DocsLink { get; set; }
        public string attachment { get; set; }
    }
}
