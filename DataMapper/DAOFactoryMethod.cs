using DataMapper.PostgresDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public static class DAOFactoryMethod
    {
        private static readonly IDAOFactory _currentDAOFactory;

        /// <summary>Initializes the <see cref="DAOFactoryMethod" /> class.</summary>
        static DAOFactoryMethod()
        {
            _currentDAOFactory = new PostgresDAOFactory();
            
        }
        /// <summary>Gets the current DAO factory.</summary>
        /// <value>The current DAO factory.</value>
        public static IDAOFactory CurrentDAOFactory
        {
            get
            {
                return _currentDAOFactory;
            }
        }
    }
}
