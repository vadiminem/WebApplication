using System.Data;
using ThinkingHome.Migrator.Framework;

[Migration(1)]
public class DbMigration : Migration
{
    public override void Apply()
    {
        Database.AddTable("NotDelete", new Column("name", DbType.String));
        Database.AddTable("Delete", new Column("name", DbType.String));
    }
}

[Migration(2)]
public class DbMigration2: Migration
{
    public override void Apply()
    {
        Database.RemoveTable("Delete");
    }
}