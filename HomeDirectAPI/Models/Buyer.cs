using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Buyers")]
    public class Buyer
    {
        [Key]
        public int BuyerID { get; set; }
        public int UserID { get; set; }
        public string BuyerType { get; set; }
        public string Details { get; set; }
        public DateTime RegDate { get; set; }
    }
}
