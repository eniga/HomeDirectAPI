using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("mortgagedashboard")]
    public class MortgageDashboard
    {
        [Key]
        public long Id { get; set; }
        public long Year { get; set; }
        public string DataType { get; set; }
        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }
    }

    public class ListMortgageDashboard : Response
    {
        public List<MortgageDashboard> mortgageDashboards { get; set; }
    }

    public class MortgageDashboardDetails : Response
    {
        public MortgageDashboard existingData { get; set; }
        public MortgageDashboard newData { get; set; }
    }
}
