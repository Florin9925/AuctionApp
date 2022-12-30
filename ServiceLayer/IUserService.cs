using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        IList<User> GetListOfUserAccounts();

        void DeleteUserAccount(User userAccount);

        void UpdateUserAccount(User userAccount);

        void GetUserAccountById(int id);

        void AddUserAccount(User userAccount);
    }
}
