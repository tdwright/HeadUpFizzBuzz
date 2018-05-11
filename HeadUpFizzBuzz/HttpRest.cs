using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HeadUpFizzBuzz
{
    public static class HttpRest
    {
        [FunctionName("HeadUpOverRest")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            var replacements = new Dictionary<int, string>
            {
                { 3, "Head" },
                { 5, "Up" }
            };
            var fb = new FizzBuzzLib.FizzBuzzer(replacements);

            string num = req.Query["number"];
            string reqBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(reqBody);
            num = num ?? data?.number;

            string json;
            if (num != null && int.TryParse(num,out int n))
            {
                json = JsonConvert.SerializeObject(fb.ProcessInt(n));
            }
            else
            {
                var seq = fb.FizzBuzz(1, 100).ToArray();
                json = JsonConvert.SerializeObject(seq);
            }
            return new OkObjectResult(json);
        }
    }
}
