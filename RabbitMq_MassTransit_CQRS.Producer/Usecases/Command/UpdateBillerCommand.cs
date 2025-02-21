using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Usecases.Command;
public record UpdateBillerCommand(int Id, string Name, decimal Price) : IRequest;
