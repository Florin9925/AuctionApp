using DomainModel.DTO;

namespace ServiceLayer.Exception;

public class InvalidUserExeption : System.Exception
{
    public InvalidUserExeption(string message) : base(message) { }
    public InvalidUserExeption(UserDto userDto) : base($"Invalid user {userDto}") { }
}