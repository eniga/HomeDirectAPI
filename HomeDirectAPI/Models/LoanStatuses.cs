using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("LoanStatuses")]
    public class LoanStatuses
    {
        [Key]
        public int LoanStatusID { get; set; }
        public string LoanStatus { get; set; }
    }
}
