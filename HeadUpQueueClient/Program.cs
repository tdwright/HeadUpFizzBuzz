using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace HeadUpQueueClient
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://headupfizzbuzz.servicebus.windows.net/;SharedAccessKeyName=client;SharedAccessKey=";
        const string ReqQueueName = "requests";
        const string RespQueueName = "response";
        private static QueueClient outQ;
        private static QueueClient inQ;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            // Get authed
            Console.WriteLine("Please provide Shared Access Key:");
            var sak = Console.ReadLine();
            var fullConnString = ServiceBusConnectionString + sak;
            
            // Setup queues
            outQ = new QueueClient(fullConnString, ReqQueueName);
            inQ = new QueueClient(fullConnString, RespQueueName);

            // Add listener
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
            inQ.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);

            // Main interaction
            Console.WriteLine("Enter number for HeadUp FizzBuzz, or blank line for 100");
            while (true)
            {
                var input = Console.ReadLine();
                await outQ.SendAsync(new Message(Encoding.UTF8.GetBytes(input)));
            }
        }

        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine(Encoding.UTF8.GetString(message.Body));
            await inQ.CompleteAsync(message.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
