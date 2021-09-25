using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDirectAPI.Models
{
    [Table("usertypes")]
    public class UserTypes
    {
        [Key]
        public long TypeID { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
    public class ListUserTypeResponse : Response
    {
        public List<UserTypes> usertypes { get; set; }
    }

    public class UserTypeResponse : Response
    {
        public UserTypes usertype { get; set; }
    }
}
