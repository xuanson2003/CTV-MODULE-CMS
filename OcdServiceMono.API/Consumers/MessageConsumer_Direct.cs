using MassTransit;
using OcdServiceMono.API.Models.Message;
using System.Threading.Tasks;
using System;

namespace OcdServiceMono.API.Consumers
{
    public class MessageConsumer_Direct : IConsumer<SimpleMessage_Direct>
    {
        public Task Consume(ConsumeContext<SimpleMessage_Direct> context)
        {
            if (context.RoutingKey() == "active") 
            {
                var message = context.Message;
                Console.WriteLine($"Received: {message.Text}");
            }
            return Task.CompletedTask;
        }
    }
}
