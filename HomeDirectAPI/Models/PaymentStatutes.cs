using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("paymentstatutes")]
    public class PaymentStatutes
    {
        [Key]
        public long PaymentStatuteID { get; set; }
        public string PaymentStatute { get; set; }
    }
}
