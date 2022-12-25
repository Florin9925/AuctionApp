using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public interface IDAOFactory
    {
        /// <summary>Gets the produc data services.</summary>
        /// <value>The produc data services.</value>
        IProductDataServices ProducDataServices
        {
            get;
        }
    }
}
