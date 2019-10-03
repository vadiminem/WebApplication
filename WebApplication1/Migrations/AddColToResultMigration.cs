using System.Data;
using ThinkingHome.Migrator.Framework;

namespace WebApplication1.Migrations
{
    [Migration(2)]
    public class AddColToResultMigration : Migration
    {
        public override void Apply()
        {
            Database.AddColumn("result", new Column("date", DbType.DateTime));
        }

        public override void Revert()
        {
            Database.RemoveColumn("result", "date");
        }
    }
}
