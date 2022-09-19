namespace Eschody.Domain.Contracts.Services;

public interface IResponse
{
    public int Code { get; }
    public string Message { get; }
}
