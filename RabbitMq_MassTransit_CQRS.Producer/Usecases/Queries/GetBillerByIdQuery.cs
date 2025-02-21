using RabbitMq_MassTransit_CQRS.Producer.Models;
using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Usecases.Queries;
public record GetBillerByIdQuery(int Id) : IRequest<Biller>;
