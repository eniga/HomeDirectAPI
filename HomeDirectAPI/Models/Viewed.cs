﻿using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("viewed")]
    public class Viewed
    {
        [Key]
        public int ID { get; set; }
        public string PropertyID { get; set; }
        public int UserID { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class ListViewedResponse : Response
    {
        public List<Viewed> data { get; set; }
    }

    public class ViewedResponse : Response
    {
        public Viewed data { get; set; }
    }
}
