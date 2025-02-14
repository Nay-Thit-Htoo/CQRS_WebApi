using MediatR;

namespace CQRS_WebApi.Usecases.Command;
public record CreateBillerCommand(string Name, bool IsActive) : IRequest<int>;
