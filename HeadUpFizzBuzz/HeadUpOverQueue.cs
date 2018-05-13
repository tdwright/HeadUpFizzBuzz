using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace HeadUpFizzBuzzFunction
{
    public static class HeadUpOverQueue
    {
        [FunctionName("HeadUpOverQueue")]
        [return: ServiceBus("response", Connection = "connection")]
        public static string Run([ServiceBusTrigger("requests", Connection = "connection")]string number, TraceWriter log)
        {
            var json = Shared.HandleRequest(number);
            log.Info(json);
            return json;
        }
    }
}
