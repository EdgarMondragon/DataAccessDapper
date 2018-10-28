using DataAccess.Infraestructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using System.Data;

namespace DataAccess
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
       where T : class, IEntityBase, new()
    {
        IConnectionFactory _connectionFactory;

        public EntityBaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool Delete(T entity)
        {
            bool isSuccess = false;
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                isSuccess = connection.Delete(entity);
                connection.Close();
            }

            return isSuccess;
        }

        public bool DeleteAll(List<T> entities)
        {
            bool isSuccess = false;
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                isSuccess = connection.Delete(entities);
                connection.Close();
            }
            return isSuccess;
        }

        public IEnumerable<T> ExecuteSPWithOutParameters(string storeProcedure)
        {
            List<T> entities = new List<T>();
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                entities = connection.Query<T>(storeProcedure, commandType: CommandType.StoredProcedure).ToList();
            }
            return entities;
        }

        public IEnumerable<T> ExecuteSPWithParameters(string storeProcedure, object parameters)
        {
            List<T> entities = new List<T>();
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                entities = connection.Query<T>(storeProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return entities;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            List<T> entities = new List<T>();
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var allEntities = connection.GetAll<T>().ToList();

                entities.AddRange(allEntities.AsQueryable().Where(predicate).Select(x => x));
                connection.Close();
            }
            return entities;
        }

        public T Get(int id)
        {
            T entity = new T();
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();

                entity = connection.Get<T>(id);
                connection.Close();

            }
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            List<T> entities = new List<T>();
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                entities = connection.GetAll<T>().ToList();
                connection.Close();
            }
            return entities;
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            T entity = new T();
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var allEntities = connection.GetAll<T>().ToList();

                entity = allEntities.AsQueryable().Where(predicate).Select(x => x).FirstOrDefault();
                connection.Close();
            }
            return entity;
        }

        public T Insert(T entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                entity.Id = (int)connection.Insert(entity);
                connection.Close();
            }
            return entity;
        }

        public bool Update(T entity)
        {
            bool isSuccess = false;
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                isSuccess = connection.Update(entity);
                connection.Close();
            }
            return isSuccess;
        }

        public bool UpdateAll(List<T> entities)
        {
            bool isSuccess = false;
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                isSuccess = connection.Update(entities);
                connection.Close();
            }
            return isSuccess;
        }
    }
}
