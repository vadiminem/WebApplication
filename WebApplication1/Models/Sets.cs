using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Sets
    {
        public Sets() { }
        public Sets(Sets sets)
        {
            Items = sets.Items;
        }
        [JsonProperty(PropertyName = "items")]
        public Items[] Items { get; set; }

        public void SetItems(Items[] items)
        {
            Items = new Items[items.Length];
            for (var i = 0; i < items.Length; i++)
            {
                Items[i] = new Items(items[i]);
            }
        }
    }
}
