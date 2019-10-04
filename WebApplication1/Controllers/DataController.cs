using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApplication.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    public class DataController : ControllerBase
    {
        private IResultRepository repository;
        private IConfigurationSection connectionStrings;

        public DataController(IResultRepository repository, IConfigurationSection connectionStrings)
        {
            this.repository = repository;
            this.connectionStrings = connectionStrings;
        }

        public async Task<IActionResult> Sync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(connectionStrings.GetSection("GetDataAddress").Value);
                if (response.IsSuccessStatusCode)
                {
                    var text = await response.Content.ReadAsStringAsync();
                    repository.Create(JsonConvert.DeserializeObject<SomeObject>(text));
                    return Ok("complete");
                }
            }
            return Ok();
        }

        public IActionResult Get()
        {
            return(Ok(repository.Get()));
        }
    }
}