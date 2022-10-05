using Eschody.Domain.Models.ValueObjects;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Eschody.Services.Mail;

public class EmailService
{
    private readonly string APIKey;
    private readonly SendGridClient _client;

    public EmailService()
    {
        APIKey = Environment.GetEnvironmentVariable("EschodySTMPKEY")!.ToString();
        _client = new SendGridClient(APIKey);
    }

    public async Task<Response> SendEmailAsync(EmailAddress from, string subject, EmailAddress emailTo, string plainTextContent, string htmlContent)
    {
        var msg = MailHelper.CreateSingleEmail(from, emailTo, subject, plainTextContent, htmlContent);
        var response = await _client.SendEmailAsync(msg);
        return response;
    }
}
