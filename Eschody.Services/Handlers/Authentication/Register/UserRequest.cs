using Eschody.Domain.Contracts.Services;

namespace Eschody.Services.Handlers.Authentication.Register;

public class UserRequest : IRequest
{
    public Guid RequestIdentifier { get; private set; }
    public DateTime Moment { get; private set; }

    public UserRequest(Guid requestIdentifier, DateTime moment)
    {
        RequestIdentifier = requestIdentifier;
        Moment = moment;
    }
}
