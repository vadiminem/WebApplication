using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Traks
    {
        [JsonProperty(PropertyName = "sets")]
        public Sets[] SetsProp { get; set; }
        [JsonProperty(PropertyName = "pos")]
        public int PosProp { get; set; }
        [JsonProperty(PropertyName = "vMin")]
        public int VMinProp { get; set; }
        [JsonProperty(PropertyName = "vMax")]
        public int VMaxProp { get; set; }
    }
}
