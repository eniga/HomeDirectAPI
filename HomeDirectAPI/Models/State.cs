using System;
using System.Collections.Generic;
using Dapper;

namespace HomeDirectAPI.Models
{
    [Table("lga")]
    public class Local
    {
        [Key]
        public int LgaID { get; set; }
        public int StateID { get; set; }
        public string lgaName { get; set; }
    }

    public class State
    {
        public string name { get; set; }
        public int id { get; set; }
        public List<Local> locals { get; set; }
    }
    [Table("state")]
    public class StateResp
    {
        public string StateName { get; set; }
        [Key]
        public int StateID { get; set; }
        //public List<Local> locals { get; set; }
    }
    public class RootObject
    {
        public State state { get; set; }
    }

    public class ListStateResponse : Response
    {
        public List<StateResp> states { get; set; }
    }
    public class StateResponse : Response
    {
        public StateResp state { get; set; }
    }
    public class LGAResponse : Response
    {
        public List<Local> lgas { get; set; }
    }

    public class LGAsResponse : Response
    {
        public Local lga { get; set; }
    }
}
