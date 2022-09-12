using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.DTOModels
{
    public class UpdateImageFilterDTO : BaseImageFilterDto
    {
        public int Id { get; set; }

        //public string? ImageFilterUrl { get; set; }

        public string? OriginalFileName { get; set; }


    }
}
