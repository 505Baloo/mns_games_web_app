using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Net.Security;


namespace mns_games_web_app.Services
{
    public class EmailSender : IEmailSender
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _fromEmail;

        public EmailSender(string smtpServParam, int smtpPortParam, string fromEmailParam)
        {
            this._smtpServer = smtpServParam;
            this._smtpPort = smtpPortParam;
            this._fromEmail = fromEmailParam;
        }

        public Task SendEmailAsync(string receiverEmail, string subject, string htmlMessage)
        {
            // Configure message
            var message = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            // Configure receiver
            message.To.Add(new MailAddress(receiverEmail));

            // Init client
            using var client = new SmtpClient(_smtpServer, _smtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("noreply.mnsgames@gmail.com", "sdWj27rwYTacJfEI"),
            };

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            client.Send(message);

            return Task.CompletedTask;
        }
    }
}
