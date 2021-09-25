using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("propertytransfer")]
    public class PropertyTransfer
    {
        [Key]
        public long ID { get; set; }
        public string UserID { get; set; }
        public string PropertyID { get; set; }
        public string BankID { get; set; }
        public DateTime? RegDate { get; set; }
        public string RegDate2 { get; set; }
    }
}
