using CalculatorApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorApi.DBContext
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }

    public class AuditRepo : IDataRepository<Audit>
    {
        readonly CalculatorDBContext _dbContext;
        public AuditRepo(CalculatorDBContext context)
        {
            _dbContext = context;
        }

        public void Add(Audit entity)
        {
            try
            {
                _dbContext.Audits.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
              //Log the error  and throw back
            }
        }

        public IEnumerable<Audit> GetAll()
        {
            return _dbContext.Audits.ToList();
        }
    }
}
