using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.Email;
using Microsoft.Extensions.Configuration;

namespace JobAutomation.Infrastructure.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public SmtpEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(
            string to,
            string subject,
            string body,
            CancellationToken cancellationToken)
        {
            var smtpConfig = _configuration.GetSection("Smtp");

            var message = new MailMessage
            {
                From = new MailAddress(
                    smtpConfig["Username"]!,
                    smtpConfig["FromName"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            message.To.Add(to);

            using var client = new SmtpClient(
                smtpConfig["Host"],
                int.Parse(smtpConfig["Port"]!))
            {
                Credentials = new NetworkCredential(
                    smtpConfig["Username"],
                    smtpConfig["Password"]),
                EnableSsl = true
            };

            await client.SendMailAsync(message, cancellationToken);
        }
    }
}
