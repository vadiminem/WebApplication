using Microsoft.Extensions.Configuration;
using System;
using ThinkingHome.Migrator;

namespace WebApplication1.Migrations
{
    public class DbMigrator
    {
        private IConfigurationSection connectionStrings = default;
        public DbMigrator(IConfigurationSection connectionStrings)
        {
            this.connectionStrings = connectionStrings;
        }

        public void StartMigration()
        {
            try
            {
                var provider = "Postgres";
                var assembly = typeof(DbMigration).Assembly;
                using (var migrator = new Migrator(provider, connectionStrings.GetSection("PostgresqlConnection").Value, assembly))
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
