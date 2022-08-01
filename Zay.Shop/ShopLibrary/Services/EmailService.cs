using IdentityProjectPractise.Services;
using Microsoft.Extensions.Options;
using ShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Models
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _options;

        //public async Task SendTestEmail(EmailRequest request)
        //{
        //    request.Subject = UpdatePlaceHolder("Hello {{UserName}} : Test Email", request.PlaceHolder);
        //    request.Body = UpdatePlaceHolder(GetEmailBody("TestEmail"), request.PlaceHolder);

        //    await SendEmail(request);
        //}

        //public async Task SendEmailForEmailConfirmation(EmailRequest request)
        //{
        //    request.Subject = UpdatePlaceHolder("Hello {{UserName}} : Confirm your Email Id", request.PlaceHolder);
        //    request.Body = UpdatePlaceHolder(GetEmailBody("EmailConfirm"), request.PlaceHolder);

        //    await SendEmail(request);
        //}

        //public async Task SendEmailForForgotPassword(EmailRequest request)
        //{
        //    request.Subject = UpdatePlaceHolder("Hello {{UserName}} : reset your Password", request.PlaceHolder);
        //    request.Body = UpdatePlaceHolder(GetEmailBody("ForgotPassword"), request.PlaceHolder);

        //    await SendEmail(request);
        //}

        public EmailService(IOptions<SMTPConfigModel> options)
        {
            _options = options.Value;
        }
        public async Task SendEmail(Message request)
        {
            MailMessage mail = new MailMessage
            {
                Subject = request.Subject,
                Body = request.Content,
                From = new MailAddress(_options.SenderAddress, _options.SenderDisplayName),
                IsBodyHtml = _options.IsBodyHtml
            };

            foreach (var toEmail in request.To)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCredential = new NetworkCredential { UserName = _options.Username, Password = _options.Password };

            SmtpClient smtp = new SmtpClient
            {
                Host = _options.Host,
                Port = _options.Port,
                EnableSsl = _options.EnableSSL,
                UseDefaultCredentials = _options.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;

            await smtp.SendMailAsync(mail);

        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));

            return body;
        }

        private string UpdatePlaceHolder(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeHolder in keyValuePairs)
                {
                    if (text.Contains(placeHolder.Key))
                    {
                        text = text.Replace(placeHolder.Key, placeHolder.Value);
                    }
                }
            }
            return text;
        }
    }
}
