using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    [Table("MortgageApplication")]
    public class MortgageApplication
    {
        [Key]
        public int MortgageId { get; set; }

        public int ProID { get; set; }
        public string ProName { get; set; }
        public string MortgageType { get; set; }
        public string AmountBorrowed { get; set; }

        public string MortgageCategory { get; set; }
        public string Paymentterms { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string CustomerBank { get; set; }
        public string EmploymentStatus { get; set; }

        public string NumberOfDependants { get; set; }
        public string AnnualIncome { get; set; }
        [ReadOnly(true)]
        public DateTime DateApplied { get; set; }
        public DateTime DateApproved { get; set; }
        //public int MyProperty { get; set; }

    }
    public class ListMortgageApplicationResponse : Response
    {
        public List<MortgageApplication> mortgageapplications { get; set; }
    }

    public class MortgageApplicationResponse : Response
    {
        public MortgageApplication mortgageapplication { get; set; }
    }
}
