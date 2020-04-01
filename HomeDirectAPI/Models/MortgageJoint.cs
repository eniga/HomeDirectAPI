using System;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("mortgage_joint")]
    public class MortgageJoint
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string AppID { get; set; }
        public string PropertyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Editable(false)]
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string DOB { get; set; }
    }
}
