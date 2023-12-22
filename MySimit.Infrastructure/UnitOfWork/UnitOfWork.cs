using MySimit.Application.IUnitOfWork;
using MySimit.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimit.Infrastructure.UnitOfWork
{
    public  class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Rollback changes if needed
        }

        public IRepository<T> GetRepository<T>()
        {
            var repository = new CountryRepository(_context);
            return (IRepository<T>)repository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
