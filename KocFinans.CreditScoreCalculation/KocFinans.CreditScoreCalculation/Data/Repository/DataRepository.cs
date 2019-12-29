using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Data.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly CreditCalculationDBContext _creditDBContext;
        public DataRepository(CreditCalculationDBContext creditDBContext)
        {
            _creditDBContext = creditDBContext;
        }
        public T Create(T entity)
        {
            try
            {
                _creditDBContext.Set<T>().Add(entity);
                _creditDBContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
