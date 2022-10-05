﻿using Eschody.Domain.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication;

public class ResponseCreateStudentAccount : Notifiable
{
    public Guid Identifier { get; private set; }
    public string StatusCode { get; private set; }
    public string Message { get; private set; }
    public string Localization { get; private set; }

    public ResponseCreateStudentAccount(StatusAPICode statusAPICode, Message message, Localization localization, IReadOnlyCollection<Notification> notifications)
    {
        Identifier = Guid.NewGuid();
        StatusCode = statusAPICode.GetStatusCode().ToString();
        Message = message.ToString();
        Localization = localization.ToString();

        AddNotifications(notifications);
    }
}