using RabbitMq_MassTransit_CQRS.Producer.Models;
using RabbitMq_MassTransit_CQRS.Producer.Usecases.Command;
using RabbitMq_MassTransit_CQRS.Producer.Usecases.Queries;
using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Services
{
    public class BillerService : IBillerService
    {
        private readonly IMediator _mediator;
        public BillerService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<int> AddBiller(CreateBillerCommand command)
        {
            var result = await _mediator.Send(command);
            return result;

        }
        public async Task<Biller> GetBillerById(int id)
        {
            var query = new GetBillerByIdQuery(id);
            return await _mediator.Send(query);
        }
    }
}
