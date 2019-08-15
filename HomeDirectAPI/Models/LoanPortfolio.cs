using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    public class LoanPortfolio
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public decimal Performing { get; set; }
        public decimal Late { get; set; }
        public decimal Default { get; set; }
        public decimal Delinquent { get; set; }
        public decimal Lost { get; set; }
        public decimal Total { get => Performing + Late + Default + Delinquent + Lost; }
    }

    public class ListLoanPortfolioResponse : Response
    {
        public List<LoanPortfolio> loanPortfolios { get; set; }
    }

    public class LoanPortfolioResponse : Response
    {
        public LoanPortfolio loanPortfolio { get; set; }
    }
}
