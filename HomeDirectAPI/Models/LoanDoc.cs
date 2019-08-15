using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("LoanDocs")]
    public class LoanDoc
    {
        [Key]
        public int DocID { get; set; }
        public int LoanID { get; set; }
        public string DocName { get; set; }
        public string DocDesc { get; set; }
        public string DocLink { get; set; }
    }

    public class ListLoanDocResponse : Response
    {
        public List<LoanDoc> loandocs { get; set; }
    }

    public class LoanDocResponse : Response
    {
        public LoanDoc loandoc { get; set; }
    }
}
