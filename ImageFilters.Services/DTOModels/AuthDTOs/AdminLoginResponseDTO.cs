using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.DTOModels
{
    public class AdminLoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public string id { get; set; }
        public string FirstName { get; set; }
    }
}
