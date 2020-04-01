using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("loanratings")]
    public class LoanRating
    {
        [Key]
        public int RatingID { get; set; }
        public int LoanID { get; set; }
        public decimal Rating { get; set; }
        public string RatingDesc { get; set; }
    }

    public class ListLoanRatingResponse : Response
    {
        public List<LoanRating> loanratings { get; set; }
    }

    public class LoanRatingResponse : Response
    {
        public LoanRating loanrating { get; set; }
    }
}
