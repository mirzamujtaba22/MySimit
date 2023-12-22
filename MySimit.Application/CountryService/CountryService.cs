using MySimit.Application.IUnitOfWork;
using MySimit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimit.Application.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork.IUnitOfWork _unitOfWork;
        private readonly IRepository<Country> _countryRepository;
        public CountryService(IUnitOfWork.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = _unitOfWork.GetRepository<Country>();
        }
        public void AddAsync(Country country)
        {
            _countryRepository.Add(country);
            _unitOfWork.Commit();
        }
    

        public async Task<int> DeleteAsync(int id)
        {
        var numberOfRow = await _countryRepository.Delete(id);
        if (numberOfRow < 0)
        {
            _unitOfWork.Commit();
        }
        return numberOfRow;
    }

        public Task<List<Country>> GetAllAsync()
        {
            return _countryRepository.GetAll();
        }

        public Task<Country?> GetByID(int countryId)
        {
            return _countryRepository.GetById(countryId);
        }

        
    }
}
