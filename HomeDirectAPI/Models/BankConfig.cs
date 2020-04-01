using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("bankconfig")]
    public class BankConfig
    {
        [Key]
        public int ConfigID { get; set; }
        public int BankID { get; set; }
        public string ConfigName { get; set; }
        public string ConfigDesc { get; set; }
        public string Item { get; set; }
        public string Value { get; set; }
    }

    public class ListBankConfigResponse : Response
    {
        public List<BankConfig> branchconfigs { get; set; }
    }

    public class BankConfigResponse : Response
    {
        public BankConfig branchconfig { get; set; }
    }
}
