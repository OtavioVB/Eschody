namespace Eschody.Domain.Conctracts.Services;

public interface IResponse
{
    public Guid Identifier { get; }
    public string StatusCode { get; }
    public string Message { get; }
    public string Localization { get; }
}
