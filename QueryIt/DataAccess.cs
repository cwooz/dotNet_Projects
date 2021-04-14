using System;
using System.Data.Entity;
using QueryIt.Models;
using System.Linq;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public interface IRepository<T> : IDisposable
    {
        void Add(T newEntity);

        void Delete(T entity);

        T FindById(int id);

        IQueryable<T> FindAll();

        int Commit();
    }

    public class SqlRepository<T> : IRepository<T> where T: class, IEntity
    {
        private DbContext _context;
        private DbSet<T> _dbSet;

        public SqlRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _dbSet.Add(newEntity);
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
