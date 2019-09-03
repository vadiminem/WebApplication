using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                return Ok(new { Result = deserializedResult.ResultProp, TimeGenerated = deserializedResult.TimeGeneratedProp });

            }
            catch
            {
                return Ok(new { ErrorMessage = deserializedResult.ErrorMessageProp, TimeGenerated = deserializedResult.TimeGeneratedProp });
            }
        }
    }
}
