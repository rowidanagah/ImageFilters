using ImageFilters.Services.DTOModels.MailDTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services.BusinessServices.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public string SendEmail(EmailDto request)
        {
            using (MailMessage message = new MailMessage())
            {
                MailAddress fromAddress = new MailAddress("EvaFilters2022@outlook.com");
                message.From = fromAddress;
                message.Subject = "Your image with Eva filters";
                message.IsBodyHtml = true;
                //message.Body = "<h1>"+request.Body+"</h1>";
                message.Body = @"<img src="+_config["BaseUrl"] + request.Body+"cid:{0} />";
                message.To.Add(request.To);
                try
                {
                    var smtpClient = new SmtpClient("smtp-mail.outlook.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("EvaFilters2022@outlook.com", "kX6qhsnBgF1RWjzgQk"),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);
                    return "success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
