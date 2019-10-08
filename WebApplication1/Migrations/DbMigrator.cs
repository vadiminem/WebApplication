using Microsoft.Extensions.Configuration;
using System;
using ThinkingHome.Migrator;
using WebApplication1.Settings;

namespace WebApplication1.Migrations
{
    public class DbMigrator
    {
        private PostgresSettings settings;
        public DbMigrator(PostgresSettings settings)
        {
            this.settings = settings;
        }

        public void StartMigration()
        {
            try
            {
                var provider = "Postgres";
                var assembly = typeof(DbMigration).Assembly;
                using (var migrator = new Migrator(provider, settings.ConnectionString, assembly))
                {
                    migrator.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
