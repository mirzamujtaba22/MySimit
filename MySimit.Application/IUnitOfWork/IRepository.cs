using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimit.Application.IUnitOfWork
{
    public interface IRepository<T>
    {
        public Task<T?> GetById(int id);
        public void Add(T card);
        public void Update(T card);
        public Task<List<T>> GetAll();
        Task<int> Delete(int id);
    }
}
