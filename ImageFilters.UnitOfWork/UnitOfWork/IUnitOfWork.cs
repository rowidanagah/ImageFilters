using ImageFilters.DB.Models;
using ImageFilters.Repository.GenericRepository;

namespace ImageFilters.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();
        IGenericRepository<ImageFilter> ImageFilterRepository { get; }
    }
}