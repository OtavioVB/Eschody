namespace Eschody.Domain.Contracts.Services;

public interface IHandler<Request, Response> where Request : IRequest where Response : IResponse
{
    public Response Handle(Request request);
}
