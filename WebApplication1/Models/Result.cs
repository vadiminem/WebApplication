using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Result
    {
        public Result() { }
        public Result(Result result)
        {
            Traks = result.Traks;
        }

        [JsonProperty(PropertyName = "traks")]
        public Traks[] Traks { get; set; }

        public void SetTraks(Traks[] traks)
        {
            Traks = new Traks[traks.Length];
            for (var i = 0; i < traks.Length; i++)
            {
                Traks[i] = new Traks(traks[i]);
            }
        }
    }
}
