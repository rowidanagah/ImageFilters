using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.DTOModels
{
    public class AdminLoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
