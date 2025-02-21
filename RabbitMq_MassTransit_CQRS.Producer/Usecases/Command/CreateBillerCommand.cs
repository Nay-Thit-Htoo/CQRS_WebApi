using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Usecases.Command;
public class CreateBillerCommand : IRequest<int>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
