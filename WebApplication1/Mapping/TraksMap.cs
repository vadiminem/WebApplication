using DapperExtensions.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class TraksMap : ClassMapper<TraksModel>
    {
        public TraksMap()
        {
            Table("traks");
            Map(x => x.Id).Column("id").Key(KeyType.Identity);
            Map(x => x.ResultId).Column("result_id");
            Map(x => x.Pos).Column("pos");
            Map(x => x.VMin).Column("v_min");
            Map(x => x.VMax).Column("v_max");
        }
    }
}
