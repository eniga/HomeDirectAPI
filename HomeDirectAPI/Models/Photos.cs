using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("photos")]
    public class Photos
    {
        [Key]
        public long id { get; set; }
        public string prop_id { get; set; }
        public string photo { get; set; }
        [ReadOnly(true)]
        public DateTime date { get; set; }
    }
}
