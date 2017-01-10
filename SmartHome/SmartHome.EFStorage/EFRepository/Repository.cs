using SmartHome.Entities.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.EFStorage.EFRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            dbSet = dbContext.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(int itemId)
        {
            T itemToDelete = dbSet.Find(itemId);
            dbSet.Remove(itemToDelete);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {                
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            query = orderBy?.Invoke(query) ?? query;

            return query.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T item)
        {
            dbSet.Attach(item);
        }
    }
}
