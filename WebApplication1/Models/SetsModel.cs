using WebApplication.Models;

namespace WebApplication1.Models
{
    public class SetsModel : Sets
    {
        public SetsModel() { }
        public SetsModel(Sets sets) : base(sets)
        {
            ItemsModel = new ItemsModel[sets.Items.Length];
            for (var i = 0; i < sets.Items.Length; i++)
            {
                ItemsModel[i] = new ItemsModel(sets.Items[i]);
            }
        }
        public int Id { get; set; }
        public int TraksId { get; set; }
        public ItemsModel[] ItemsModel { get; set; }
    }
}
