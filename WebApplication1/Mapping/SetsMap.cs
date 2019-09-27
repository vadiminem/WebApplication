using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
