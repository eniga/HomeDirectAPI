using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string HQAddress { get; set; }
        public string BankCategory { get; set; }
        public int BankAdminUserID { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
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
