﻿using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loanbuyers")]
    public class LoanBuyer
    {
        [Key]
        public long LoanBuyerID { get; set; }
        public string LoanBuyerName { get; set; }
        public string BuyerCategory { get; set; }
        public long AdminUserID { get; set; }
        public string HQAddress { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
    }

    public class ListLoanBuyerResponse : Response
    {
        public List<LoanBuyer> loanbuyers { get; set; }
    }

    public class LoanBuyerResponse : Response
    {
        public LoanBuyer loanbuyer { get; set; }
    }
}
