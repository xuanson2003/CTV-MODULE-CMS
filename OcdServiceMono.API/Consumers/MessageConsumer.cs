using MassTransit;
using OcdServiceMono.API.Models.Message;
using System.Threading.Tasks;
using System;

namespace OcdServiceMono.API.Consumers
{
    public class MessageConsumer : IConsumer<SimpleMessage>
    {
        public Task Consume(ConsumeContext<SimpleMessage> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received: {message.Text}");
            return Task.CompletedTask;
        }
    }
}
