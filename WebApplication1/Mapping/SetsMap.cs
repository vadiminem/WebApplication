using DapperExtensions.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class SetsMap : ClassMapper<SetsModel>
    {
        public SetsMap()
        {
            Table("sets");
            Map(x => x.Id).Column("id").Key(KeyType.Identity);
            Map(x => x.TraksId).Column("traks_id");
        }
    }
}
