using Informacioni_sistemi___Projekat.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Informacioni_sistemi___Projekat.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("belkisa.dazdarevic1@gmail.com", "kvazilend5")
            };

            return client.SendMailAsync(
                new MailMessage(from: "belkisa.dazdarevic1@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
