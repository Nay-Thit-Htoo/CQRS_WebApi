using MediatR;

namespace CQRS_WebApi.Usecases.Command;
public record UpdateBillerCommand(int Id, string Name, decimal Price) : IRequest;
