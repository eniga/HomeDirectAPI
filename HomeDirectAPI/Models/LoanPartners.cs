using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    [Table("loanpartners")]
    public class LoanPartners
    {
        [Key]
        public int PartnerID { get; set; }
        public int MortgageLoanID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DOB { get; set; }
    }
    public class ListpartersResponse : Response
    {
        public List<LoanPartners> partners { get; set; }
    }

    public class PartnersResponse : Response
    {
        public LoanPartners partner { get; set; }
    }
}
