using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace API_PRO.Data
{
    public class EmailConfirm : Controller
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "radwaabouzed@gmail.com";
            var fPassword = "yourpassword";

            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fMail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = true;

            var smtpClint = new SmtpClient("smtp-mail.outlook.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassword),
                Port = 587
            };

            smtpClint.Send(theMsg);
        }
    }
}
