using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBooking.Domain.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
       // void AddRange(IEnumerable<TEntity> entities);
       // void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}
