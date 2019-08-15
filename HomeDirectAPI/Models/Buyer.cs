using System;
using System.Collections.Generic;
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

    public class ListBuyerResponse : Response
    {
        public List<Buyer> buyers { get; set; }
    }

    public class BuyerResponse : Response
    {
        public Buyer buyer { get; set; }
    }
}
