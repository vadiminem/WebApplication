using System.Data;
using ThinkingHome.Migrator.Framework;

[Migration(2)]
public class DbMigration2 : Migration
{
    public override void Apply()
    {
        Database.AddTable("Result",
            new Column("id", DbType.Int32));
        Database.AddPrimaryKey("Result", "id");
        Database.AddTable("Traks",
            new Column("id", DbType.Int32),
            new Column("resultId", DbType.Int32),
            new Column("pos", DbType.Int32),
            new Column("vMin", DbType.Int32),
            new Column("vMax", DbType.Int32));
        Database.AddPrimaryKey("Traks", "id");
        Database.AddTable("Sets",
            new Column("id", DbType.Int32),
            new Column("traksId", DbType.Int32));
        Database.AddPrimaryKey("Sets", "id");
        Database.AddTable("Items",
            new Column("id", DbType.Int32),
            new Column("setsId", DbType.Int32),
            new Column("time", DbType.DateTime),
            new Column("value", DbType.Double),
            new Column("randValue", DbType.Int32));
        Database.AddPrimaryKey("Items", "id");
    }

    public override void Revert()
    {
        Database.RemoveTable("Result");
        Database.RemoveTable("Traks");
        Database.RemoveTable("Sets");
        Database.RemoveTable("Items");
    }
}