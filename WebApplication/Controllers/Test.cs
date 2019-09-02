using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class Test : Controller
    {
        [HttpGet]
        public SomeObject GetData()
        {
            var path = "wwwroot/Data/test_set1.json";
            var deserializedResult = new SomeObject();
            if (System.IO.File.Exists(path))
            {
                deserializedResult = JsonConvert.DeserializeObject<SomeObject>(System.IO.File.ReadAllText(path));
            }
            return deserializedResult;
        }
    }
}
