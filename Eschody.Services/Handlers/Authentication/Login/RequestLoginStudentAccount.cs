using Eschody.Domain.Contracts.Services.Handlers;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class RequestLoginStudentAccount : Notifiable, IRequest
{
    public Guid Identifier { get; private set; }
    public DateTime RequestTime { get; private set; }
}
