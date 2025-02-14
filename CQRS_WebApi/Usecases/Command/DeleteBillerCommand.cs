using MediatR;

namespace CQRS_WebApi.Usecases.Command;
public record DeleteBillerCommand(int Id) : IRequest;
