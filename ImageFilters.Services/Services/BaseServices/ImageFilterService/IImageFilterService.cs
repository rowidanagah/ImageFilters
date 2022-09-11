using ImageFilters.DB.Models;
using ImageFilters.Services.DTOModels;
using System.Linq.Expressions;

namespace ImageFilters.Services.Services
{
    public interface IImageFilterService
    {
        Task UpdateImageFilter(ImageFilter imageFilter);

        Task AddImageFilter(ImageFilter imageFilter);
        Task<ImageFilter?> GetImageFilter(Expression<Func<ImageFilter, bool>> expression);
        Task<IList<ImageFilter>> GetImageFilters(Expression<Func<ImageFilter, bool>> expression);
    }
}