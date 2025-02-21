using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Usecases.Command;
public record DeleteBillerCommand(int Id) : IRequest;
