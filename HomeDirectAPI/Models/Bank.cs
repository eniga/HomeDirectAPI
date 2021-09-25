using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("banks")]
    public class Bank
    {
        [Key]
        public long BankID { get; set; }
        public string BankName { get; set; }
        public string HQAddress { get; set; }
        public string BankCategory { get; set; }
        public long BankAdminUserID { get; set; }
        [NotMapped]
        public string BankAdminUser { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
        public decimal Rate { get; set; }
        public long Balance { get; set; }
    }

    public class ListBankResponse : Response
    {
        public List<Bank> banks { get; set; }
    }

    public class BankResponse : Response
    {
        public Bank bank { get; set; }
    }
}
