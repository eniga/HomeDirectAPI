using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("properties")]
    public class Property
    {
        [Key]
        public int ProID { get; set; }
        public int SellerID { get; set; }
        public string ProType { get; set; }
        public string ProName { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
        public string Views { get; set; }
        public string ViewerStats { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
    }

    public class ListPropertyResponse : Response
    {
        public List<Property> properties { get; set; }
    }

    public class PropertyResponse : Response
    {
        public Property property { get; set; }
    }
}
