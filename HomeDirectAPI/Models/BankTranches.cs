using System;
using System.Collections.Generic;

namespace HomeDirectAPI.Models
{
    
    public class BankTranches
    {
        public string Tranche { get; set; }
        public decimal Performing { get; set; }
        public decimal Late { get; set; }
        public decimal Default { get; set; }
        public decimal Delinquent { get; set; }
        public decimal Lost { get; set; }
        public decimal Total { get => Performing + Late + Default + Delinquent + Lost; }
    }

    public class ListBankTranchesResponse : Response
    {
        public List<BankTranches> tranches { get; set; }
    }

    public class BankTranchesResponse : Response
    {
        public BankTranches tranche { get; set; }
    }
}
