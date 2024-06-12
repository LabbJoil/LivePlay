
using System.Net;
using System.Net.Mail;

namespace LivePlay.Infrastructure.Other;

public class EmailProvider
{
    private readonly MailAddress ServerEmail = new("tejlordzon4@gmail.com", "Live&Play");         // закрепить в appsettings
    private readonly SmtpClient Smtp = new("smtp.gmail.com", 587)
    {
        Credentials = new NetworkCredential("tejlordzon4@gmail.com", "ter.45mj"),
        EnableSsl = true
    };

    public void SendEmail(string email, int[] code)
    {
        MailAddress to = new(email);
        MailMessage message = new(ServerEmail, to)
        {
            Subject = "Код подтверждения",
            Body = $"<h2>Код доступа {code}</h2>",
            IsBodyHtml = true
        };

        Smtp.Send(message);
    }
}
