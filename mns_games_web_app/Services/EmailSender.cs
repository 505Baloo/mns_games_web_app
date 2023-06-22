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

        public async Task SendEmailAsync(string receiverEmail, string subject, string htmlMessage)
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
                TargetName = "STARTTLS/smtp.sendinblue.com",
            };

            //ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            try
            {
                // Send email
                await client.SendMailAsync(message);
            }
            // Handle SmtpException
            catch (SmtpException ex)
            {
                if (ex.InnerException is System.Security.Authentication.AuthenticationException)
                {
                    Console.WriteLine("Certificate validation failed. Error: " + ex.InnerException.Message);
                }
                else
                {
                    // Other SMTP-related exception
                    Console.WriteLine("SMTP error occurred. Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred while sending the email. Error: " + ex.Message);
                // throw new CustomEmailException("Failed to send email.", ex);
            }
        }
    }
}
