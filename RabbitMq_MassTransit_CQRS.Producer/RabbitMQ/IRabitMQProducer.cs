namespace RabbitMq_MassTransit_CQRS.Producer.RabbitMQ
{
    public interface IRabitMQProducer
    {
        Task SendProductMessageAsync<T>(T message);
    }
}
