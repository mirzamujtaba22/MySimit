using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimit.Application.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
        void Rollback();
        IRepository<T> GetRepository<T>();
    }
}
