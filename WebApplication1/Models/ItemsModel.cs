using WebApplication.Models;

namespace WebApplication1.Models
{
    public class ItemsModel : Items
    {
        public ItemsModel() { }
        public ItemsModel(Items items) : base(items)
        {

        }
        public int Id { get; set; }
        public int SetsId { get; set; }
    }
}
