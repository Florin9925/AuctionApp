using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper.PostgresDAO
{
    class PostgresDAOFactory : IDAOFactory
    {
        public IProductDataServices ProducDataServices
        {
            get
            {
                return new SQLProductDataServices();
            }
        }
    }
}
