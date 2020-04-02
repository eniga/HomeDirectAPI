using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loanmarketshare")]
    public class LoanMarketShare
    {
        [Key]
        public int ShareID { get; set; }
        public string TitleHolder { get; set; }
        public decimal Amount { get; set; }
        public decimal Repayments { get; set; }
        public string Statutes { get; set; }
        public decimal Rating { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int ProcessedBy { get; set; }
    }

    public class ListLoanMarketShareResponse : Response
    {
        public List<LoanMarketShare> loanmarketshares { get; set; }
    }

    public class LoanMarketShareResponse : Response
    {
        public LoanMarketShare loanmarketshare { get; set; }
    }
}
