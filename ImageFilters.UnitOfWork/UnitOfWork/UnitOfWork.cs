using ImageFilters.DB.Models;
using ImageFilters.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ImageFiltersContext _context;
        public IGenericRepository<ImageFilter> ImageFilterRepository { get; }
        public UnitOfWork(
                 ImageFiltersContext context,
                 IGenericRepository<ImageFilter> imageFilterRepository)
        {
            _context = context;
            ImageFilterRepository = imageFilterRepository;
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
