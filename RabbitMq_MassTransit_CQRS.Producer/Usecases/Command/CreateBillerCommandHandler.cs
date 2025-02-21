using RabbitMq_MassTransit_CQRS.Producer.Models;
using MediatR;

namespace RabbitMq_MassTransit_CQRS.Producer.Usecases.Command
{
    public class CreateBillerCommandHandler : IRequestHandler<CreateBillerCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateBillerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBillerCommand request, CancellationToken cancellationToken)
        {
            var biller = new Biller { Code = request.Name, NameEng = request.Name, NameMmr = request.Name, IsActive = request.IsActive };
            _context.Billers.Add(biller);
            await _context.SaveChangesAsync(cancellationToken);
            return biller.Id;
        }
    }
}
