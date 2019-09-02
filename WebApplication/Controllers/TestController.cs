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
        public SomeObject GetData()
        {
            var deserializedResult = new SomeObject();
            if (System.IO.File.Exists(path))
            {
                deserializedResult = JsonConvert.DeserializeObject<SomeObject>(System.IO.File.ReadAllText(path));
            }
            return deserializedResult;
        }
    }
}
