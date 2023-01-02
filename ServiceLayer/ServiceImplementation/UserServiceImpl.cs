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

        void ICRUDService<UserDto>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<UserDto>.Insert(UserDto dto)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<UserDto>.Update(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
