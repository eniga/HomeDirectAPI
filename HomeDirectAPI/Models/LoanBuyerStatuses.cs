using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loanbuyerstatuses")]
    public class LoanBuyerStatuses
    {
        [Key]
        public long LoanBuyerStatusID { get; set; }
        public string LoanBuyerStatus { get; set; }
    }
}
