using RabbitMq_MassTransit_CQRS.Producer.Models;
using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Usecases.Queries;
public class GetProductByIdQueryHandler : IRequestHandler<GetBillerByIdQuery, Biller>
{
    private readonly AppDbContext _context;

    public GetProductByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Biller> Handle(GetBillerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Billers.FindAsync(request.Id);
    }
}


