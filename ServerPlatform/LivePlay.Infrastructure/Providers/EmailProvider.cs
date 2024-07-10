
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

public class EmailProvider : IEmailProvider
{
    private readonly SmtpClient Smtp;
    private SmtpClientOptions SmtpOptions { get; }

    public EmailProvider(IOptions<SmtpClientOptions> options)
    {
        SmtpOptions = options.Value;
        Smtp = new SmtpClient();
        Smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        Smtp.Authenticate(SmtpOptions.SmtpEmail, SmtpOptions.Password);
    }

    public BaseException? SendCodeEmail(string email, string code)
    {
        try
        {
            MimeMessage message = new()
            {
                Subject = "Код подтверждения",
                Body = new TextPart(TextFormat.Html) { Text = $"<h2>Код доступа {code}</h2>" }
            };
            message.From.Add(MailboxAddress.Parse(SmtpOptions.SmtpEmail));
            message.To.Add(MailboxAddress.Parse(email));
            Smtp.Send(message);
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

    public void Disconect()
    {
        Smtp.Disconnect(true);
    }
}
