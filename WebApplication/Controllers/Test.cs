using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class Test : Controller
    {
        [HttpGet("GetData")]
        public SomeObject GetData()
        {
            var path = "Data/test_set1.json";
            var deserializedResult = new SomeObject();
            if (System.IO.File.Exists(path))
            {
                deserializedResult = JsonConvert.DeserializeObject<SomeObject>(System.IO.File.ReadAllText(path));
            }
            return deserializedResult;
        }
    }
}
