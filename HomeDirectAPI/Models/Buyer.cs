using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("buyers")]
    public class Buyer
    {
        [Key]
        public long BuyerID { get; set; }
        public long UserID { get; set; }
        public string BuyerType { get; set; }
        public string Details { get; set; }
        public DateTime? RegDate { get; set; }
    }

    public class ListBuyerResponse : Response
    {
        public List<Buyer> buyers { get; set; }
    }

    public class BuyerResponse : Response
    {
        public Buyer buyer { get; set; }
    }
}
