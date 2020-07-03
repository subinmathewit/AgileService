using AgileDashBoardService.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgileDashBoardService.Data.Repositories.Interfaces
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entites);

        TEntity FindByKey<KeyType>(KeyType id);
        Task<TEntity> FindByKeyAsync<KeyType>(KeyType id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll();


    }
}
