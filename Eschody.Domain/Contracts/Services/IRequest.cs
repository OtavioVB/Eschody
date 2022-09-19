namespace Eschody.Domain.Contracts.Services;

public interface IRequest
{
    public Guid RequestIdentifier { get; }
    public DateTime Moment { get; }
}
