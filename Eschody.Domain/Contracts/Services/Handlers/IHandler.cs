namespace Eschody.Domain.Contracts.Services.Handlers;

public interface IHandler<TResponse, TRequest> where TResponse : IResponse where TRequest : IRequest
{
    public Task<TResponse> Handle(TRequest request);
}
