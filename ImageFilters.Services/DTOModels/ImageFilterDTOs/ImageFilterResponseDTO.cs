using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.DTOModels
{
    public class ImageFilterResponseDTO 
    {
        public int Id { get; set; }
        public string ImageFilterUrl { get; set; }
        public string OriginalFileName { get; set; }
        public int StatusId { get; set; }

    }

}
