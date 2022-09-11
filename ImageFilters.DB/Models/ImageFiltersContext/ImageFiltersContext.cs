using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageFilters.DB.Models
{
    public class ImageFiltersContext : IdentityDbContext<User>
    {
        public ImageFiltersContext(DbContextOptions<ImageFiltersContext> options) : base(options){}

        public virtual DbSet<ImageFilter> ImageFilters { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

    }
}
