using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Sets
    {
        [JsonProperty(PropertyName = "items")]
        public Items[] Items { get; set; }
    }
}
