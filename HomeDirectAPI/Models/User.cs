using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserType { get; set; }
        public bool AccountStatus { get; set; }
        public string UserCategory { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime RegDate { get; set; }
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
