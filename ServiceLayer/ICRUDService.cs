using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ICRUDService<T>
    {
        IList<T> GetAll();

        void Delete(T entity);

        void Update(T entity);

        void GetById(int id);

        void Insert(T entity);
    }
}
