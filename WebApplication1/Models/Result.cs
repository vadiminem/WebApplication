using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "traks")]
        public Traks[] TraksProp { get; set; }
    }
}
