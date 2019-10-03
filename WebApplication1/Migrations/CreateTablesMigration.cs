using System.Data;
using ThinkingHome.Migrator.Framework;

namespace WebApplication1.Migrations
{
    [Migration(1)]
    public class CreateTablesMigration : Migration
    {
        public override void Apply()
        {
            Database.AddTable("result",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity));

            Database.AddTable("traks",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("result_id", DbType.Int32),
                new Column("pos", DbType.Int32),
                new Column("v_min", DbType.Double),
                new Column("v_max", DbType.Double));

            Database.AddTable("sets",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("traks_id", DbType.Int32));

            Database.AddTable("items",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("sets_id", DbType.Int32),
                new Column("time", DbType.DateTime),
                new Column("value", DbType.Double),
                new Column("rand_value", DbType.Int32));
        }

        public override void Revert()
        {
            Database.RemoveTable("result");
            Database.RemoveTable("traks");
            Database.RemoveTable("sets");
            Database.RemoveTable("items");
        }
    }
}
