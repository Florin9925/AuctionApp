using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Exception
{
    public class InvalidUserExeption : System.Exception
    {
        public InvalidUserExeption(string message) : base(message) { }
    }
}
