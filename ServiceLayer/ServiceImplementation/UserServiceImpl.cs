using DataMapper;
using DataMapper.PostgresDAO;
using DomainModel;
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
        private IUserDataServices _userAccountDataServices;

        public UserServiceImpl(IUserDataServices userAccountDataServices)
        {
            this._userAccountDataServices = userAccountDataServices;
        }

        public void AddUserAccount(User userAccount)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAccount(User userAccount)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetListOfUserAccounts()
        {
            throw new NotImplementedException();
        }

        public void GetUserAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserAccount(User userAccount)
        {
            throw new NotImplementedException();
        }
    }
}
