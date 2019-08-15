using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("Permissions")]
    public class Permissions
    {
        [Key]
        public int PermID { get; set; }
        public int PermRoleID { get; set; }
        public string PermName { get; set; }
        public string PermModule { get; set; }
    }

    public class ListPermissionsResponse : Response
    {
        public List<Permissions> permissions { get; set; }
    }

    public class PermissionsResponse : Response
    {
        public Permissions permission { get; set; }
    }
}
