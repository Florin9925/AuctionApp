using DomainModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Exception
{
    public class InvalidUserExeption : System.Exception
    {
        public InvalidUserExeption(string message) : base(message) { }
        public InvalidUserExeption(UserDto userDto) : base($"Invalid user {userDto}") { }
    }
}
