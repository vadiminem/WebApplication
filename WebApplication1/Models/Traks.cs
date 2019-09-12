using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Traks
    {
        [JsonProperty(PropertyName = "sets")]
        public Sets[] Sets { get; set; }
        [JsonProperty(PropertyName = "pos")]
        public int Pos { get; set; }
        [JsonProperty(PropertyName = "vMin")]
        public int VMin { get; set; }
        [JsonProperty(PropertyName = "vMax")]
        public int VMax { get; set; }
    }
}
