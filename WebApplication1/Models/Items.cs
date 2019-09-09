using System;
using Newtonsoft.Json;


namespace WebApplication.Models
{
    public class Items
    {
        [JsonProperty(PropertyName = "time")]
        public DateTime TimeProp { get; set; }
        [JsonProperty(PropertyName = "value")]
        public float ValueProp { get; set; }
    }
}
