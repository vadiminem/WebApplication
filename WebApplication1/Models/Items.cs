using System;
using Newtonsoft.Json;


namespace WebApplication.Models
{
    public class Items
    {
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
        [JsonProperty(PropertyName = "value")]
        public float Value { get; set; }
        public int RandValue { get; set; }
    }
}
