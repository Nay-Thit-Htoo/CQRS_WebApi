using RabbitMq_MassTransit_CQRS.Producer.Models;
using RabbitMq_MassTransit_CQRS.Producer.Usecases.Command;

namespace RabbitMq_MassTransit_CQRS.Producer.Services
{
    public interface IBillerService
    {
        Task<int> AddBiller(CreateBillerCommand command);
        Task<Biller> GetBillerById(int id);
    }
}
