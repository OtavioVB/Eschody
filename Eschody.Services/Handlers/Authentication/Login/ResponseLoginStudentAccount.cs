using Eschody.Domain.Contracts.Services.Handlers;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class ResponseLoginStudentAccount : Notifiable, IResponse
{
    public Guid Identifier { get; private set; }
    public string StatusCode { get; private set; }
    public string Message { get; private set; }
    public string Localization { get; private set; }

    public ResponseLoginStudentAccount(Guid identifier, string statusCode, string message, string localization)
    {
        Identifier = identifier;
        StatusCode = statusCode;
        Message = message;
        Localization = localization;
    }
}
