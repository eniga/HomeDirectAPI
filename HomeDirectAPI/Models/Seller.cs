using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("sellers")]
    public class Seller
    {
        [Key]
        public int SellerID { get; set; }
        public int UserID { get; set; }
        public string SellerType { get; set; }
        public string Details { get; set; }
        public DateTime RegDate { get; set; }
    }

    public class ListSellerResponse : Response
    {
        public List<Seller> sellers { get; set; }
    }

    public class SellerResponse : Response
    {
        public Seller seller { get; set; }
    }
}
