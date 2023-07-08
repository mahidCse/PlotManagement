using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        T GetById(int id);
        IList<T> GetAll();
        void Remove(int id);
        void Remove(T entity);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, string includeProperties = "", bool isTrackingOff = false);

        IEnumerable<T> Get(out int total, out int totalDisplay, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int pageIndex = 1,
            int pageSize = 10, bool isTrackingOff = false);


     }
}
