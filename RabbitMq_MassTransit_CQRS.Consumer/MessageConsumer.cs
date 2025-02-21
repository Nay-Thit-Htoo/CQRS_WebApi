using MassTransit;
using Newtonsoft.Json;


namespace RabbitMq_MassTransit_CQRS.Consumer;

public class MessageConsumer : IConsumer<string>
{
    public async Task Consume(ConsumeContext<string> context)
    {
        var payloadJson = JsonConvert.DeserializeObject(context.Message);
        Console.WriteLine($"Received message: {payloadJson}");
        await Task.CompletedTask;
    }
}