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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataController : ControllerBase
    {
        ResultRepository rep = default;

        public DataController(string connectionString)
        {
            rep = new ResultRepository(connectionString);
            var provider = "Postgres";
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
                var text = await response.Content.ReadAsStringAsync();
                    rep.Create(JsonConvert.DeserializeObject<SomeObject>(text));
                    return Ok("complete");
                
            }
            return Ok();
        }

        public IActionResult Get()
        {
            return(Ok(rep.Get()));
        }
    }
}