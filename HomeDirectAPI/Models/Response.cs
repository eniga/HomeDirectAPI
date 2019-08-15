using System;
namespace HomeDirectAPI.Models
{
    public class Response
    {
        public bool Status { get; set; }
        public string Description { get; set; }
    }

    public class MortgageResponse
    {
        public int MortgageId { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }

    public class MortgageResponseCount
    {
        public int count { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
