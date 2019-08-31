using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
        public string timeGenerated { get; set; }
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
        //[JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime time { get; set; }
        [DataMember]
        public float value { get; set; }
    }
}
