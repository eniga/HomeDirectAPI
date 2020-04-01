using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("bookmarks")]
    public class Bookmarks
    {
        [Key]
        public int ID { get; set; }
        public string PropertyID { get; set; }
        public int UserID { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class ListBookmarksResponse : Response
    {
        public List<Bookmarks> data { get; set; }
    }

    public class BookmarksResponse : Response
    {
        public Bookmarks data { get; set; }
    }
}
