using System.Data;
using ThinkingHome.Migrator.Framework;

[Migration(1)]
public class DbMigration : Migration
{
    public override void Apply()
    {
        Database.AddTable("Result",
            new Column("id", DbType.Int32, ColumnProperty.PrimaryKey),
            new Column("traksId", DbType.Int32));
        Database.AddTable("Traks",
            new Column("id", DbType.Int32, ColumnProperty.PrimaryKey),
            new Column("resultId", DbType.Int32),
            new Column("pos", DbType.Int32),
            new Column("vMin", DbType.Int32),
            new Column("vMax", DbType.Int32));
        Database.AddTable("Sets",
            new Column("id", DbType.Int32, ColumnProperty.PrimaryKey),
            new Column("traksId", DbType.Int32));
        Database.AddTable("Items",
            new Column("id", DbType.Int32, ColumnProperty.PrimaryKey),
            new Column("setsId", DbType.Int32),
            new Column("time", DbType.DateTime),
            new Column("value", DbType.Double));
    }

    public override void Revert()
    {
        Database.RemoveTable("Result");
        Database.RemoveTable("Traks");
        Database.RemoveTable("Sets");
        Database.RemoveTable("Items");
    }
}