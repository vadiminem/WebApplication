using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Traks
    {
        public Traks() { }
        public Traks(Traks traks)
        {
            Sets = traks.Sets;
            Pos = traks.Pos;
            VMax = traks.VMax;
            VMin = traks.VMin;
        }

        [JsonProperty(PropertyName = "sets")]
        public Sets[] Sets { get; set; }
        [JsonProperty(PropertyName = "pos")]
        public int Pos { get; set; }
        [JsonProperty(PropertyName = "vMin")]
        public int VMin { get; set; }
        [JsonProperty(PropertyName = "vMax")]
        public int VMax { get; set; }

        public void SetSets(Sets[] sets)
        {
            Sets = new Sets[sets.Length];
            for (var i = 0; i < sets.Length; i++)
            {
                Sets[i] = new Sets(sets[i]);
            }
        }
    }
}
