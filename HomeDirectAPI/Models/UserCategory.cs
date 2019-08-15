using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("UserCategories")]
    public class UserCategory
    {
        [Key]
        public int CatID { get; set; }
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
