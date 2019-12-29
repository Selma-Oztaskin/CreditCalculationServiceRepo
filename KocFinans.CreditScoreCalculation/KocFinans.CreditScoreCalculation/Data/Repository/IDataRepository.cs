using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Data.Repository
{
    public interface IDataRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        int Delete(int id);
        int Update(T entity);
    }
}
