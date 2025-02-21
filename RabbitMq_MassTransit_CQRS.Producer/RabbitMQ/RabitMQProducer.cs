using MassTransit;
using Newtonsoft.Json;

namespace RabbitMq_MassTransit_CQRS.Producer.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {

        private readonly IBus _bus;

        public RabitMQProducer(IBus bus)
        {
            _bus = bus;
        }
        public async Task SendProductMessageAsync<T>(T message)
        {
            var jsonMessage = JsonConvert.SerializeObject(message);
            Console.WriteLine($"Your send message:{jsonMessage}");
            await _bus.Publish(message);
        }
    }
}
