using DapperExtensions.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class ItemsMap : ClassMapper<ItemsModel>
    {
        public ItemsMap()
        {
            Table("items");
            Map(x => x.Id).Column("id").Key(KeyType.Identity);
            Map(x => x.SetsId).Column("sets_id");
            Map(x => x.Time).Column("time");
            Map(x => x.Value).Column("value");
            Map(x => x.RandValue).Column("rand_value");
        }
    }
}
