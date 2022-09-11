using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.DTOModels
{
    public class UpdateImageFilterDTO
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageFilterUrl { get; set; }
        [Range(minimum:1,maximum:2)]
        public int StatusId { get; set; }
        public string? OriginalFileName { get; set; }


    }
}
