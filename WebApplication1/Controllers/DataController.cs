using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApplication.Models;
using WebApplication1.Interfaces;
using WebApplication1.Settings;

namespace WebApplication1.Controllers
{
    public class DataController : ControllerBase
    {
        private IResultRepository repository;
        private RoutesSettings routesSettings;

        public DataController(IResultRepository repository, RoutesSettings routesSettings)
        {
            this.repository = repository;
            this.routesSettings = routesSettings;
        }

        public async Task<IActionResult> Sync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(routesSettings.GetDataAddress);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var text = await response.Content.ReadAsStringAsync();
                        repository.Create(JsonConvert.DeserializeObject<SomeObject>(text));
                        return Ok("complete");
                    }
                    catch (Exception ex)
                    {
                        return Ok(ex.Message);
                    }
                }
            }
            return Ok("error");
        }

        public IActionResult Get()
        {
            return(Ok(repository.Get()));
        }
    }
}