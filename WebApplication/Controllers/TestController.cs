using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly string path;

        public TestController(string path)
        {
            this.path = path;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var deserializedResult = new SomeObject();
            try
            {
                if (System.IO.File.Exists(path))
                {
                    deserializedResult = JsonConvert.DeserializeObject<SomeObject>(System.IO.File.ReadAllText(path));
                }
                else throw new FileNotFoundException();
                return Ok(new { Result = deserializedResult.ResultProp, TimeGenerated = DateTime.Now });

            }
            catch (Exception ex)
            {
                return Ok(new { ErrorMessage = ex.Message, TimeGenerated = DateTime.Now });
            }
        }
    }
}
