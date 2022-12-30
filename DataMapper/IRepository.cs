using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public interface IRepository<T>
    {
        T Insert(T entity);

        T Update(T item);

        void Delete(T entity);

        T GetByID(object id);

        IList<T> GetAll();
    }
}
