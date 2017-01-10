using SmartHome.Entities.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.RepositoryInterfaces
{
    public interface IRepository<T> where T: class
    {
        void Add(T item);

        void Update(T item);

        void Delete(T item);

        void Delete(int itemId);

        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetById(int itemId); 
    }
}
