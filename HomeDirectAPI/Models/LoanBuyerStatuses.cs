using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("LoanBuyerStatuses")]
    public class LoanBuyerStatuses
    {
        [Key]
        public int LoanBuyerStatusID { get; set; }
        public string LoanBuyerStatus { get; set; }
    }
}
