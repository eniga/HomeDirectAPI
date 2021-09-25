using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("bankbranches")]
    public class BankBranch
    {
        [Key]
        public long BranchID { get; set; }
        public long BankID { get; set; }
        public string BranchName { get; set; }
        public long BranchManagerUserID { get; set; }
        public long BranchManagerRoleID { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
    }

    public class ListBankBranchesResponse : Response
    {
        public List<BankBranch> branches { get; set; }
    }

    public class BankBranchesResponse : Response
    {
        public BankBranch branch { get; set; }
    }
}
