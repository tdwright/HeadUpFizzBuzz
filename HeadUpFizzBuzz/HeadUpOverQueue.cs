using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Text;

namespace HeadUpFizzBuzzFunction
{
    public static class HeadUpOverQueue
    {
        const string ServiceBusConnectionString = "Endpoint=sb://headupfizzbuzz.servicebus.windows.net/;SharedAccessKeyName=client;SharedAccessKey=Emsv8xhhFfHeCwil4EU/kAnlGaUudTDo+h13y/BbKOY=";
        const string QueueName = "response";
        private static QueueClient queue;

        [FunctionName("HeadUpOverQueue")]
        public static void Run([ServiceBusTrigger("request", Connection = "Endpoint=sb://headupfizzbuzz.servicebus.windows.net/;SharedAccessKeyName=client;SharedAccessKey=Emsv8xhhFfHeCwil4EU/kAnlGaUudTDo+h13y/BbKOY=")]string number, TraceWriter log)
        {
            var json = Shared.HandleRequest(number);
            queue = new QueueClient(ServiceBusConnectionString, QueueName);
            queue.SendAsync(new Message(Encoding.UTF8.GetBytes(json)));
        }
    }
}
