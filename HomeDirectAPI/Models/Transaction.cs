using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int TxnID { get; set; }
        public DateTime TxnDate { get; set; }
        public int BuyerID { get; set; }
        public int UserID { get; set; }
        public decimal Repayment { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Outstanding { get; set; }
        public DateTime DueDate { get; set; }
        public string Bank { get; set; }
        public string LoanStatus { get; set; }
    }

    public class ListTransactionResponse : Response
    {
        public List<Transaction> transactions { get; set; }
    }

    public class TransactionResponse : Response
    {
        public Transaction transaction { get; set; }
    }
}
