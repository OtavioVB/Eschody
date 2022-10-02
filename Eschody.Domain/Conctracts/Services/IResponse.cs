using Flunt.Notifications;

namespace Eschody.Domain.Conctracts.Services;

public interface IResponse
{
    public Guid Identifier { get; set; }
    public int StatusCode { get; }
    public IReadOnlyCollection<Notification> notifications { get; }
}
