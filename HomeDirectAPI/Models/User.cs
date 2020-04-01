using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Editable(false)]
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public string Email { get; set; }
        [IgnoreSelect]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string Country { get; set; }
        public string Pic { get; set; }
        public string DOB { get; set; }
        public string GovID { get; set; }
        public string UserType { get; set; }
        public string UserCategory { get; set; }
        public string AccountStatus { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public decimal Ucode { get; set; }
        public decimal Balance { get; set; }
        public DateTime RegDate { get; set; }
        public string RegDate2 { get; set; }
        public decimal vCode { get; set; }
        public string vCodeStatus { get; set; }
        public string ZipCode { get; set; }
    }

    public class ListUserResponse : Response
    {
        public List<User> users { get; set; }
    }

    public class UserResponse : Response
    {
        public User user { get; set; }
    }
}
