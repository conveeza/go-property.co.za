using System;
using System.Configuration;
using MailKit.Net.Smtp;
using MimeKit;

namespace go_property.co.za.Mailkit
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _fromEmail;

        public EmailService()
        {
            _smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            _smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            _smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
            _smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            _fromEmail = ConfigurationManager.AppSettings["SmtpUser"];
        }

        public void SendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Go Property - Website", _fromEmail));
            emailMessage.To.Add(new MailboxAddress("Go Property", emailModel.To));
            emailMessage.Subject = emailModel.Subject;
            emailMessage.Body = new TextPart("html") { Text = emailModel.Content };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    client.Authenticate(_smtpUsername, _smtpPassword);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
