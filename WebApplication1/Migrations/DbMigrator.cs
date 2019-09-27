using Npgsql;
using System;
using ThinkingHome.Migrator;

namespace WebApplication1.Migrations
{
    public class DbMigrator
    {

        private string connectionStringWithDbName = default;
        private string connectionString = default;
        public DbMigrator(string connectionStringWithDbName, string connectionString)
        {
            this.connectionString = connectionString;
            this.connectionStringWithDbName = connectionStringWithDbName;
        }

        public void StartMigration()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var createDb = new NpgsqlCommand(@"
                    create database testwebapidb
                    with owner = postgres
                    encoding = 'utf-8'
                    connection limit = -1;", connection);
                    createDb.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
            finally
            {
                var provider = "Postgres";
                var assembly = typeof(DbMigration).Assembly;
                using (var migrator = new Migrator(provider, connectionStringWithDbName, assembly))
                {
                    migrator.Migrate();
                }
            }
        }
    }
}
