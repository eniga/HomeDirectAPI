using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("developers")]
    public class Developers
    {
        [Key]
        public int ID { get; set; }
        public string DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Editable(false)]
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        [IgnoreSelect]
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [ReadOnly(true)]
        public DateTime RegDate { get; set; }
        public string AccountStatus { get; set; }
    }

    public class ListDeveloperResponse : Response
    {
        public List<Developers> developers { get; set; }
    }

    public class DeveloperResponse : Response
    {
        public Developers developer { get; set; }
    }
}
