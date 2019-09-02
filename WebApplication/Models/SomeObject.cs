using Newtonsoft.Json;
using System;

namespace WebApplication.Models
{
    [Serializable]
    public class SomeObject
    {
        [JsonProperty(PropertyName = "result")]
        public Result ResultProp { get; set; }
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessageProp { get; set; }
        [JsonProperty(PropertyName = "timeGenerated")]
        public DateTime TimeGeneratedProp { get; set; }
    }
}
