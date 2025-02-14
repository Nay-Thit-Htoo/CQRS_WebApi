using MediatR;

namespace CQRS_WebApi.Usecases.Queries;
public record GetBillerByIdQuery(int Id) : IRequest<Biller>;