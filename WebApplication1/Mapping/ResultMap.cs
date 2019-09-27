using DapperExtensions.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class ResultMap : ClassMapper<ResultModel>
    {
        public ResultMap()
        {
            Table("result");
            Map(x => x.Id).Column("id").Key(KeyType.Identity);
            Map(x => x.Date).Column("date");
        }
    }
}
