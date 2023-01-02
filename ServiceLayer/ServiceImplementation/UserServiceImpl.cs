using DataMapper;
using DataMapper.PostgresDAO;
using DomainModel.DTO;
using DomainModel.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceImplementation
{
    public class UserServiceImpl : IUserService
    {
        private IUserDataServices userAccountDataServices;

        public UserServiceImpl(IUserDataServices userAccountDataServices)
        {
            this.userAccountDataServices = userAccountDataServices;
        }

        void ICRUDService<UserDto>.Delete(UserDto dto)
        {
            throw new NotImplementedException();
        }

        IList<UserDto> ICRUDService<UserDto>.GetAll()
        {
            var users = userAccountDataServices.GetAll();

            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(new UserDto(user));
            }

            return usersDto;
        }

        UserDto? ICRUDService<UserDto>.GetById(int id)
        {
            var user = userAccountDataServices.GetByID(id);

            if (user != null)
            {
                return new UserDto(user);
            }
            return null;
        }

        UserDto ICRUDService<UserDto>.Insert(UserDto dto)
        {
            throw new NotImplementedException();
        }

        UserDto ICRUDService<UserDto>.Update(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
