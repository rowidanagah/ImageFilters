using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.DTOModels
{
    public class ListResponseDTO<T>
    {
        public List<T> Items { get; set; }
    }
}
