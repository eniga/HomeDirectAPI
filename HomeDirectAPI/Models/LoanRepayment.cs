using System;
using System.Collections.Generic;

namespace HomeDirectAPI.Models
{
    public class LoanRepayment
    {
        public long RepaymentID { get; set; }
        public string TitleHolder { get; set; }
        public decimal LoanAmount { get; set; }
        public long Payments { get; set; }
        public string PaymentStatutes { get; set; }
        public string MortgageBank { get; set; }
        public string Timeline { get; set; }
        public decimal PerformanceRating { get; set; }
    }

    public class ListLoanRepaymentResponse : Response
    {
        public List<LoanRepayment> list { get; set; }
    }

    public class LoanRepaymentResponse : Response
    {
        public LoanRepayment repayment { get; set; }
    }
}
