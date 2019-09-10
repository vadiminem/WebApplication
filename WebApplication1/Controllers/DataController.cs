using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThinkingHome.Migrator;
using WebApplication.Models;

namespace WebApplication1.Controllers
{
    public class DataController : ControllerBase
    {

        public DataController()
        {
            var provider = "Postgres";
            var connectionString = "User ID=postgres;Password=1234;host=localhost; port=5432; database=testwebapidb;";
            var assembly = typeof(DbMigration).Assembly;

            using (var migrator = new Migrator(provider, connectionString, assembly))
            {
                migrator.Migrate();
            }
        }

        HttpClient client = new HttpClient();
        public async Task<IActionResult> Sync()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/test/getdata");
            if (response.IsSuccessStatusCode)
            {
                if (response.IsSuccessStatusCode)
                {
                    return Ok(JsonConvert.DeserializeObject<SomeObject>(await response.Content.ReadAsStringAsync()));
                }
            }
            return Ok();
        }

        public void Get()
        {

        }
    }
}