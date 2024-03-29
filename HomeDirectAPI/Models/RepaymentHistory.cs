﻿using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("repaymenthistory")]
    public class RepaymentHistory
    {
        [Key]
        public long RepaymentID { get; set; }
        public long LoanID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Repayment { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Outstanding { get; set; }
        public string DueDate { get; set; }
    }

    public class ListRepaymentHistoryResponse : Response
    {
        public List<RepaymentHistory> repayments { get; set; }
    }

    public class RepaymentHistoryResponse : Response
    {
        public RepaymentHistory repayment { get; set; }
    }

    public class TotalRepaymentsResponse : Response
    {
        public decimal totalRepayments { get; set; }
    }
}
