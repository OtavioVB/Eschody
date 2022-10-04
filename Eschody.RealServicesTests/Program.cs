using SendGrid;
using SendGrid.Helpers.Mail;

namespace Eschody.RealServicesTests;

public class Program
{
    static void Main(string[] args)
    {
        var emailService = new EmailService(Environment.GetEnvironmentVariable("EschodySTMPKEY", EnvironmentVariableTarget.User));
        emailService.SendEmailAsync(new EmailAddress("suporte@eschody.com.br"), "Teste", new EmailAddress("contato.otaviovbsc@gmail.com"), "Teste", "<b>Teste</b>");
    }
}

public class EmailService
{
    private readonly string _apiKey;
    private readonly SendGridClient _client;

    public EmailService(string apiKey)
    {
        _apiKey = apiKey;
        _client = new SendGridClient(_apiKey);
    }

    public async Task<Response> SendEmailAsync(EmailAddress from, string subject, EmailAddress emailTo, string plainTextContent, string htmlContent)
    {
        var msg = MailHelper.CreateSingleEmail(from, emailTo, subject, plainTextContent, htmlContent);
        var response = await _client.SendEmailAsync(msg);
        return response;
    }
}
