using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("permissions")]
    public class Permissions
    {
        [Key]
        public long PermID { get; set; }
        public long PermRoleID { get; set; }
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
