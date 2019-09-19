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
        private IResultRepository repository;

        public DataController(IResultRepository repository)
        {
            this.repository = repository;
        }

        HttpClient client = new HttpClient();
        public async Task<IActionResult> Sync()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/test/getdata");
            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                    repository.Create(JsonConvert.DeserializeObject<SomeObject>(text));
                    return Ok("complete");
                
            }
            return Ok();
        }

        public IActionResult Get()
        {
            return(Ok(repository.Get()));
        }
    }
}