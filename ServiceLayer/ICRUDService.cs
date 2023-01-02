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

        void Delete(T dto);

        T Update(T dto);

        T GetById(int id);

        T Insert(T dto);
    }
}
