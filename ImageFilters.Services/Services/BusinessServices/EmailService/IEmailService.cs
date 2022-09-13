using ImageFilters.Services.DTOModels.MailDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services.BusinessServices.EmailService
{
    public interface IEmailService
    {
        string SendEmail(EmailDto request);
    }
}
