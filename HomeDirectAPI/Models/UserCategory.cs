using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("usercategories")]
    public class UserCategory
    {
        [Key]
        public long CatID { get; set; }
        public string CatName { get; set; }
        public string CatDescription { get; set; }
    }

    public class ListUserCategoryResponse : Response
    {
        public List<UserCategory> usercategories { get; set; }
    }

    public class UserCategoryResponse : Response
    {
        public UserCategory usercategory { get; set; }
    }
}
