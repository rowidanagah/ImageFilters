using ImageFilters.DB.Models;
using ImageFilters.Services.DTOModels;
using ImageFilters.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services
{
    public class ImageFilterService : IImageFilterService
    {
        private readonly IUnitOfWork unitOfWork;

        public ImageFilterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task UpdateImageFilter(ImageFilter imageFilter)
        {
            unitOfWork.ImageFilterRepository.Update(imageFilter);
            await unitOfWork.SaveChanges();
        }

        public async Task<ImageFilter?> GetImageFilter(Expression<Func<ImageFilter, bool>> expression)
        {
           return await unitOfWork.ImageFilterRepository.FirstOrDefault(expression);
        }

        public async Task<IList<ImageFilter>> GetImageFilters(Expression<Func<ImageFilter, bool>> expression)
        {
            return await unitOfWork.ImageFilterRepository.GetData(expression);
        }

        public async Task AddImageFilter(ImageFilter imageFilter)
        {
            unitOfWork.ImageFilterRepository.Add(imageFilter);
            await unitOfWork.SaveChanges();
        }

        public  async Task DeleteImageFilter(int id)
        {
            unitOfWork.ImageFilterRepository.Delete(id);
            await unitOfWork.SaveChanges();
        }
    }
}
