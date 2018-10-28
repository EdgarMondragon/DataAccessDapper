using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        bool Update(T entity);
        bool UpdateAll(List<T> entities);
        bool Delete(T entity);
        bool DeleteAll(List<T> entities);
        IEnumerable<T> ExecuteSPWithOutParameters(string storeProcedure);
        IEnumerable<T> ExecuteSPWithParameters(string storeProcedure, object parameters);
    }
}
