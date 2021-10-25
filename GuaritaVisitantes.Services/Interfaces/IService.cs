using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IService<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        int Count();
    }
}
