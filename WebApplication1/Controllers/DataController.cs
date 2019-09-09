using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkingHome.Migrator;

namespace WebApplication1.Controllers
{
    public class DataController : ControllerBase
    {

        public DataController()
        {
            var version = 10;
            var provider = "Postgres";
            var connectionString = "User ID=postgres;Password=1234;host=localhost; port=5432; database=testwebapidb;";
            var assembly = typeof(DbMigration).Assembly;

            using (var migrator = new Migrator(provider, connectionString, assembly))
            {
                migrator.Migrate(version);
            }
        }

        HttpClient client = new HttpClient();
        public async Task<string> Sync()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/test/getdata");
            if (response.IsSuccessStatusCode)
            {
                /*Product product = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsAsync<Product>();
                }
                return product;*/
            }
            return "hello";
        }

        public void Get()
        {

        }
    }
}