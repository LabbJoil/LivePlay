using Microsoft.Extensions.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Application.Background;

public class VerifyEmail : BackgroundService
{
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

        }
    }

    private readonly string _sendGridApiKey;
    private readonly string _senderEmail;


    private async Task SendVerificationEmailAsync(string email, string code, CancellationToken stoppingToken)
    {
        var client = new SendGridClient(_sendGridApiKey);
        var from = new EmailAddress(_senderEmail, "Your App");
        var to = new EmailAddress(email);
        var subject = "Email Verification";
        var plainTextContent = $"Your verification code is: {code}";
        var htmlContent = $"<strong>Your verification code is:</strong> {code}";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg, stoppingToken);

        Console.WriteLine($"Email sent with status code: {response.StatusCode}");
    }

}