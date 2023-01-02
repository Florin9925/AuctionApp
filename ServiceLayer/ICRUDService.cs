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

        void Update(T dto);

        void GetById(int id);

        void Insert(T dto);
    }
}
