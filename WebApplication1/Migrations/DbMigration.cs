using System.Data;
using ThinkingHome.Migrator.Framework;

[Migration(8)]
public class DbMigration : Migration
{
    public override void Apply()
    {
        Database.RemoveColumn("Result", "traks");
        Database.RenameColumn("Result", "id", "resultid");
        Database.RenameColumn("Traks", "id", "traksid");
        Database.RenameColumn("Sets", "id", "setsid");
        Database.RenameColumn("Items", "id", "itemsid");
    }

}