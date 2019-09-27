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
public class DbMigration2 : Migration
{
    public override void Apply()
    {
        Database.RemoveTable("Delete");
    }
}

[Migration(3)]
public class DbMigration3 : Migration
{
    public override void Apply()
    {
        Database.AddColumn("NotDelete",
            new Column("id", DbType.Int32, ColumnProperty.Identity));
    }
}

[Migration(4)]
public class DbMigration4 : Migration
{
    public override void Apply()
    {
        Database.RemoveColumn("NotDelete", "id");
        Database.AddColumn("NotDelete",
            new Column("id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity));
    }
}

[Migration(5)]
public class DbMigration5 : Migration
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

    [Migration(6)]
    public class DbMigration6 : Migration
    {
        public override void Apply()
        {
            Database.AddColumn("result", new Column("date", DbType.DateTime));
        }
    }

    [Migration(7)]
    public class DbMigration7 : Migration
    {
        public override void Apply()
        {
            Database.RemoveTable("notdelete");
        }
    }
}