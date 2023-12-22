using Microsoft.EntityFrameworkCore;
using MySimit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimit.Infrastructure.Repositories
{
    public class CountryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Country> _dbSet;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Country>();
        }

        public void Add(Country country)
        {
            _dbSet.Add(country);
        }
        public async Task<int> Delete(int id)
        {
            var row = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (row != null)
            {
                _dbSet.Remove(row);
                return 1;
            }
            return 0;
        }

        public async Task<List<Country>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Country?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

