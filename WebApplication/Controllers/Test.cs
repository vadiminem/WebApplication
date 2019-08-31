using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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
                var ms = new MemoryStream(System.IO.File.ReadAllBytes(path));
                var dateFormatSettings = new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-ddTH:mm:ss")
                };
                var ser = new DataContractJsonSerializer(deserializedResult.GetType(), dateFormatSettings);
                deserializedResult = ser.ReadObject(ms) as SomeObject;
                ms.Close();
                Console.WriteLine(deserializedResult.timeGenerated);
            }
            return deserializedResult;
        }
    }
}
