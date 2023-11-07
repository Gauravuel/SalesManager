
using Microsoft.Extensions.Options;
using MyManager.Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Server.Services
{
    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpconfig;
        private const string templatePath = @"Template/{0}.html";

        public async Task sendAccountconfirmationLink(EmailCred cred)
        {
            cred.Subject = Dynamic("Hi, {{Username}} Please verify your account ", cred.DynamicData);
            cred.Body = Dynamic(GetEmailBody("EmailRegistration"), cred.DynamicData);
            await SendEmail(cred);
        }

        //public async Task SendTwoFactorToken(EmailCred cred)
        //{
        //    cred.Subject = Dynamic("Hi, {{Username}} here is your 2FA token", cred.DynamicData);
        //    cred.Body = Dynamic(GetEmailBody("2FA"), cred.DynamicData);
        //    await SendEmail(cred);
        //}

        public async Task sendForgetPasswordEmail(EmailCred cred)
        {
            cred.Subject = Dynamic("Hi, {{Username}}", cred.DynamicData);
            cred.Body = Dynamic(GetEmailBody("ForgetPassword"), cred.DynamicData);
            await SendEmail(cred);
        }

        public async Task sendChangeEmail(EmailCred cred)
        {
            cred.Subject = Dynamic("Hi, {{Username}}", cred.DynamicData);
            cred.Body = Dynamic(GetEmailBody("ChangeEmail"), cred.DynamicData);
            await SendEmail(cred);
        }

        public EmailService(IOptions<SMTPConfigModel> smtpconfig)
        {
            _smtpconfig = smtpconfig.Value;
        }

        private async Task SendEmail(EmailCred emailCred)
        {
            MailMessage mail = new MailMessage
            {
                Subject = emailCred.Subject,
                Body = emailCred.Body,
                From = new MailAddress(_smtpconfig.SenderAddress, _smtpconfig.SenderName),
                IsBodyHtml = _smtpconfig.IsBodyHTML
            };
            mail.To.Add(emailCred.Email);

            NetworkCredential networkcredential = new NetworkCredential(_smtpconfig.Username, _smtpconfig.Password);
            SmtpClient smtpclient = new SmtpClient
            {
                Host = _smtpconfig.Host,
                Port = _smtpconfig.Port,
                EnableSsl = true,
                UseDefaultCredentials = _smtpconfig.USerDefaultCredentials,
                Credentials = networkcredential
            };
            mail.BodyEncoding = Encoding.Default;
            await smtpclient.SendMailAsync(mail);
        }

        private string GetEmailBody(string tamplateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, tamplateName));
            return body;
        }
        private string Dynamic(string text, List<KeyValuePair<string, string>> keyValue)
        {
            if (!string.IsNullOrEmpty(text) && keyValue != null)
            {
                foreach (var keys in keyValue)
                {
                    if (text.Contains(keys.Key))
                    {
                        text = text.Replace(keys.Key, keys.Value);
                    }
                }

            }
            return text;
        }
    }
}
