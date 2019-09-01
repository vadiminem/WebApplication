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
        [DataMember]
        public List<Traks> traks;
    }

    public class Traks
    {
        [DataMember]
        public List<Sets> sets;
        [DataMember]
        public int pos { get; set; }
        [DataMember]
        public int vMin { get; set; }
        [DataMember]
        public int vMax { get; set; }

    }

    public class Sets
    {
        [DataMember]
        public List<Items> items;
    }

    public class Items
    {
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public float value { get; set; }
    }


}
