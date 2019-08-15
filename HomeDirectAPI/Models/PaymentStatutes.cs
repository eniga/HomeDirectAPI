using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("PaymentStatutes")]
    public class PaymentStatutes
    {
        [Key]
        public int PaymentStatuteID { get; set; }
        public string PaymentStatute { get; set; }
    }
}
