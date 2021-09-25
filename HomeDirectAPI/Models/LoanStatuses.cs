using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loanstatuses")]
    public class LoanStatuses
    {
        [Key]
        public long LoanStatusID { get; set; }
        public string LoanStatus { get; set; }
        public string Role { get; set; }
    }
}
