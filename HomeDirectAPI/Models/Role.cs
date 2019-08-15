using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string UserCategory { get; set; }
        public string UserType { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
    }

    public class ListRoleResponse : Response
    {
        public List<Role> roles { get; set; }
    }

    public class RoleResponse : Response
    {
        public Role role { get; set; }
    }
}
