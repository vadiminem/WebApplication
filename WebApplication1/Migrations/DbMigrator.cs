using ThinkingHome.Migrator;

namespace WebApplication1.Migrations
{
    public class DbMigrator
    {
        private string connectionString = default;
        public DbMigrator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void StartMigration()
        {
            var provider = "Postgres";
            var assembly = typeof(DbMigration).Assembly;
            using (var migrator = new Migrator(provider, connectionString, assembly))
            {
                migrator.Migrate();
            }
        }
    }
}
