using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.DB.Models
{
    public class ImageFilter
    {
        public int Id { get; set; }
        public string ImageFilterUrl { get; set; }
        public string OriginalFileName { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; }
    }
}
