using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loandocs")]
    public class LoanDoc
    {
        [Key]
        public long DocID { get; set; }
        public long LoanID { get; set; }
        public long MortgageId { get; set; }
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
