namespace Eschody.Domain.Contracts.Services.Handlers;

public interface IResponse
{
    public Guid Identifier { get; }
    public string StatusCode { get; }
    public string Message { get; }
    public string Localization { get; }
}
