using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using DAL.Models;

using Email.Service;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace DAL.Repositories
{
    public class MailService : IMailService
    {
        public async Task<string> SendWelcomeEmailAsync(WelcomeRequest request)
        {
            var verifyUrl = "https://localhost:44349/Email/FeedbackForm/" + request.FeedbackId;
            var link = verifyUrl;
            var mailSettings = new MailSettings()
            {
                //Mail = "info@code2night.com",
                //DisplayName = "Shubham Batra",
                //Password = "Code2night",
                //Host = "webmail.code2night.com",
                //Port = 587
                Mail = "shubhambatra1994@gmail.com",
                DisplayName = "Shubham Batra",
                Password = "wszmjsahxjgmnggj",
                Host = "smtp.gmail.com",
                Port = 587
            };


            string FilePath = HttpContext.Current.Server.MapPath("\\Templates\\WelcomeTemplate.html");
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail).Replace("[feedbackForm]", link);
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = $"Welcome {request.UserName}";
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return "";
        }


    }
}