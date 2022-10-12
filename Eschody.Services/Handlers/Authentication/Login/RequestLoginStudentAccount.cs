using Eschody.Domain.Conctracts.Services;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class RequestLoginStudentAccount : Notifiable, IRequest
{
    public Guid Identifier { get; private set; }
    public DateTime RequestTime { get; private set; }
}
