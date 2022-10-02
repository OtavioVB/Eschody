using Flunt.Notifications;

namespace Eschody.Flunt.Notifications;

public interface INotifiable
{
    public bool IsValid { get; }
    public IReadOnlyCollection<Notification> Notifications { get; }
    public void Assert(Notifiable item);
}
