
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Abstracts;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace LivePlay.Server.Infrastructure.Providers;

public class EmailProvider(IOptions<SmtpClientOptions> options) : IEmailProvider
{
    private readonly SmtpClientOptions _smtpOptions = options.Value;

    public BaseException? SendCodeEmail(string email, string code)
    {
        try
        {
            var smtp = Connect();
            MimeMessage message = new()
            {
                Subject = "Код подтверждения",
                Body = new TextPart(TextFormat.Html) { Text = $"<h2>Код доступа {code}</h2>" }
            };
            message.From.Add(MailboxAddress.Parse(_smtpOptions.SmtpEmail));
            message.To.Add(MailboxAddress.Parse(email));
            smtp.Send(message);
            smtp.Disconnect(true);
            return null;
        }
        catch (SmtpCommandException ex)
        {
            return new RequestException(ErrorCode.ServerError, $"Something went wrong. Maybe email {email} not valid", ex.Message);
        }
        catch (Exception ex)
        {
            return new  ServerException(ErrorCode.ServerError, ex.Message);
        }
    }

    private SmtpClient Connect()
    {
        var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_smtpOptions.SmtpEmail, _smtpOptions.Password);
        return smtp;
    }
}
