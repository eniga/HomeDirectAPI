using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeDirectAPI.Models
{
    [Table("wallet")]
    public class Wallet
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string TransactionID { get; set; }
        public string PayStatus { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime Date { get; set; }
        public string Date2 { get; set; }
    }

    public class ListWalletResponse : Response
    {
        public List<Wallet> wallets { get; set; }
    }

    public class WalletResponse : Response
    {
        public Wallet wallet { get; set; }
    }
}
