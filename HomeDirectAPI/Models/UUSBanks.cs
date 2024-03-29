﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeDirectAPI.Models
{
    [Table("uusbanks")]
    public class UUSBanks
    {
        [Key, Required]
        public long BankId { get; set; }
        [NotMapped]
        public long AgeBracketTop { get; set; }
        public long AgeBracketBottom { get; set; }
        public string Eligibility { get; set; }
        public string LoanToValue { get; set; }
        public decimal LoanAmount { get; set; }
        public long Tenor { get; set; }
        public decimal InterestRate { get; set; }
        public string DocumentsRequired { get; set; }
        public string LoanRepayment { get; set; }
        public string Charges { get; set; }
        public string Categories { get; set; }
        public string ProductName { get; set; }
    }

    public class UUSBanksResponse : Response
    {
        public UUSBanks uus { get; set; }
    }

    public class ListUUSBanksResponse : Response
    {
        public List<UUSBanks> uus { get; set; }
    }
}
