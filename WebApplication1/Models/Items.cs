using System;
using Newtonsoft.Json;


namespace WebApplication.Models
{
    public class Items
    {
        public Items() { }
        public Items(Items items)
        {
            Time = items.Time;
            Value = items.Value;
            RandValue = items.RandValue;
        }
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }
        [JsonProperty(PropertyName = "value")]
        public float Value { get; set; }
        public int RandValue { get; set; }
    }
}
