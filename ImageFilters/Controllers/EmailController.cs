using ImageFilters.Services.DTOModels.MailDTO;
using ImageFilters.Services.Services.BusinessServices.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ImageFilters.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        public string SendMail(EmailDto request)
        {
          return  emailService.SendEmail(request);
        }
    }
}