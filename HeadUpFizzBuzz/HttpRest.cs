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
            var seq = fb.FizzBuzz(1, 100).ToArray();
            var json = JsonConvert.SerializeObject(seq);

            return  (ActionResult)new OkObjectResult(json);
        }
    }
}
