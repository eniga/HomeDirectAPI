using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("morgagecategories")]
    public class MortgageCategories
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
