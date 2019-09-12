using Newtonsoft.Json;
using System;

namespace WebApplication.Models
{
    [Serializable]
    public class SomeObject
    {
        [JsonProperty(PropertyName = "result")]
        public Result Result { get; set; }
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty(PropertyName = "timeGenerated")]
        public DateTime TimeGenerated { get; set; }
    }
}
