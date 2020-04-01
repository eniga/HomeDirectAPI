using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    [Table("mortgageloanapplication")]
    public class MortgageLoanApplication
    {
        [Key]
        public int MortgageLoanID { get; set; }
        public string ApplicationID { get; set; }
        public int UserID { get; set; }
        public string ProID { get; set; }
        public int CustomerID { get; set; }
        public string ProName { get; set; }
        public string MortgageType { get; set; }
        public Decimal AmountBorrowed { get; set; }
        public string MortgageCategory { get; set; }
        public string Paymentterms { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Editable(false)]
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerBank { get; set; }
        public string EmploymentStatus { get; set; }
        public string EmployerName { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerPhone { get; set; }
        public string EmployerEmail { get; set; }
        public string NumberOfDependants { get; set; }
        public string AnnualIncome { get; set; }
        public string PrefferedFinInst { get; set; }
        public string ContactConsent { get; set; }
        public string StatutoryAcceptanceConsent { get; set; }
        public string BusinessTermsConsent { get; set; }
        public string AuthorisationConsent { get; set; }
        [ReadOnly(true)]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? LoanDate { get; set; }
        public string LoanStatus { get; set; }
        public string LGA { get; set; }
        public string State { get; set; }
        public string Rate { get; set; }
        public string BankID { get; set; }
    }

    public class ListMortgageLoanResponse : Response
    {
        public List<MortgageLoanApplication> applications{ get; set; }
    }

    public class MortgageLoanResponse : Response
    {
        public MortgageLoanApplication application { get; set; }
    }

    public class MortgageLoansResponse : MortgageResponse
    {
        public MortgageLoanApplication application { get; set; }
    }

    public class MortgageLoansCount : MortgageResponseCount
    {
        public MortgageLoanApplication application { get; set; }
    }

    public class UpdateLoanStatus
    {
        public int MortgageLoanID { get; set; }
        public string LoanStatus { get; set; }
    }

    public class UpdateLoanStatus2 : UpdateLoanStatus
    {
        public DateTime ApprovedDate { get; set; }
    }
}
