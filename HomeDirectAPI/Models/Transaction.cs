using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Key]
        public int TxnID { get; set; }
        public DateTime TxnDate { get; set; }
        public int BuyerID { get; set; }
        public int UserID { get; set; }
        public string RepaytxID { get; set; }
        public decimal Amount { get; set; }
        public string RepaymentID { get; set; }
        public string LoanID { get; set; }
        public string DueDate { get; set; }
        public string Bank { get; set; }
        public string LoanStatus { get; set; }
        public string InvoiceID { get; set; }
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
