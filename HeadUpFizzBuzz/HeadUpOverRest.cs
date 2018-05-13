using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace HeadUpFizzBuzzFunction
{
    public static class HeadUpOverRest
    {
        [FunctionName("HeadUpOverRest")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            // Really awkward way to get the number value from either GET or POST...
            string num = req.Query["number"];
            string reqBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(reqBody);
            num = num ?? data?.number;

            // Process the number and return the JSON
            string json = Shared.HandleRequest(num);
            log.Info(json);
            return new OkObjectResult(json);
        }
    }
}
