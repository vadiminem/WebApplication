using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication.Models
{
    [DataContract]
    public class SomeObject
    {
        [DataMember]
        public Result result;
        [DataMember]
        public string errorMessage { get; set; }
        [DataMember]
        public DateTime timeGenerated { get; set; }
    }

    public class Result
    {
        public List<Traks> traks;
    }

    public class Traks
    {
        public List<Sets> sets;
        public int pos { get; set; }
        public int vMin { get; set; }
        public int vMax { get; set; }

    }

    public class Sets
    {
        public List<Items> items;
    }

    public class Items
    {
        public DateTime time { get; set; }
        public float value { get; set; }
    }


}
