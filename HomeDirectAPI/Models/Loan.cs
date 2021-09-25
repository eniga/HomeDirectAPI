using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loans")]
    public class Loans
    {
        [Key]
        public long LoanID { get; set; }
        public long PropertyID { get; set; }
        public long UserID { get; set; }
        public string TitleHolder { get; set; }
        public decimal LoanAmount { get; set; }
        public long PaymentStatuteID { get; set; }
        public string PaymentStatute { get; set; }
        public long MortgageBankID { get; set; }
        public string MortgageBank { get; set; }
        public long Repayments { get; set; }
        public long Timeline { get; set; }
        public decimal PerformanceRating { get; set; }
        public decimal Score { get; set; }
        [ReadOnly(true)]
        public DateTime DateCreated { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime LoanDate { get; set; }
        public long LoanStatusID { get; set; }
        public string LoanStatus { get; set; }
        public long LoanBuyerStatusID { get; set; }
        public string LoanBuyerStatus { get; set; }
        public string ApplicationID { get; set; }
        public string MortgageType { get; set; }
        public long LoanBuyerID { get; set; }
        public string TransferComments { get; set; }
    }

    public class ListLoanResponse : Response
    {
        public List<Loans> loans { get; set; }
    }

    public class LoanResponse : Response
    {
        public Loans loan { get; set; }
    }

    public class PendingLoanResponse : Response
    {
        public long NumberOfPending { get; set; }
    }

    public class LoanGroupByBank
    {
        public long BankID { get; set; }
        public string BankName { get; set; }
        public decimal FlaggedValue { get; set; }
        public long Units { get; set; }
    }

    public class LoanGroupByBankResponse : Response
    {
        public List<LoanGroupByBank> loans { get; set; }
        public List<MortgageLoanApplication> applications { get; set; }
    }

    public class AdvanceQueryResult
    {
        public string Country { get; set; }
        public decimal LoanAmount { get; set; }
    }

    public class AdvanceQueryResponse : Response
    {
        public List<AdvanceQueryResult> result { get; set; }
    }
}
