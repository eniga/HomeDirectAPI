using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("customers")]
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Editable(false)]
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        [IgnoreSelect]
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [ReadOnly(true)]
        public DateTime RegDate { get; set; }
        public bool AccountStatus { get; set; }
    }

    public class ListCustomerResponse : Response
    {
        public List<Customers> customers { get; set; }
    }

    public class CustomerResponse : Response
    {
        public Customers customer { get; set; }
    }
}
