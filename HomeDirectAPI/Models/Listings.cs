using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("listings")]
    public class Listings
    {
        [Key]
        public int id { get; set; }
        public string user_id { get; set; }
        [NotMapped]
        public string user_name { get; set; }
        public string prop_title { get; set; }
        public string prop_id { get; set; }
        public string mainphoto { get; set; }
        public string prop_address { get; set; }
        public string prop_state { get; set; }
        public string prop_desc { get; set; }
        public string prop_lat { get; set; }
        public string prop_long { get; set; }
        public decimal prop_price { get; set; }
        public decimal prop_area { get; set; }
        public string prop_areaunits { get; set; }
        public string prop_type { get; set; }
        public string prop_beds { get; set; }
        public string prop_baths { get; set; }
        public string prop_kitchen { get; set; }
        public string prop_garage { get; set; }
        public string prop_pool { get; set; }
        public string prop_amenities { get; set; }
        public string prop_category { get; set; }
        public string prop_avail { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public string dateadded { get; set; }
        public string prop_lga { get; set; }
    }

    public class ListListingsResponse : Response
    {
        public List<Listings> listings { get; set; }
    }

    public class ListingsResponse : Response
    {
        public Listings listing { get; set; }
    }
}
