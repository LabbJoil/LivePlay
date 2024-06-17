
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using LivePlay.Server.Core.Options;
using Microsoft.Extensions.Options;

namespace LivePlay.Server.Infrastructure.Providers;

public class EmailProvider
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

    public void SendCodeEmail(string email, string code)
    {
        MimeMessage message = new()
        {
            Subject = "Код подтверждения",
            Body = new TextPart(TextFormat.Html) { Text = $"<h2>Код доступа {code}</h2>" }
        };
        message.From.Add(MailboxAddress.Parse(SmtpOptions.SmtpEmail));
        message.To.Add(MailboxAddress.Parse(email));
        Smtp.Send(message);
    }

    public void Disconect()
    {
        Smtp.Disconnect(true);
    }
}
