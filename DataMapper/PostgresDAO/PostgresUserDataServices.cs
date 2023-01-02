using DomainModel.Entity;
using FluentValidation;

namespace DataMapper.PostgresDAO
{
    public class PostgresUserDataServices : IUserDataServices
    {
        private readonly AuctionAppContext context;
        private readonly UserValidator validations;

        public PostgresUserDataServices(AuctionAppContext context, UserValidator validations)
        {
            this.context = context;
            this.validations = validations;
        }

        void IRepository<User>.Delete(User entity)
        {
            var userAccount = context.Users.Find(entity.Id);
            if (userAccount == null)
                return;

            context.Users.Remove(userAccount);
            context.SaveChanges();
        }

        IList<User> IRepository<User>.GetAll()
        {
            return context.Users.ToList();
        }

        User IRepository<User>.GetByID(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            return context.Users.Find(id);
        }

        User IRepository<User>.Insert(User entity)
        {
            validations.ValidateAndThrow(entity);

            var user = context.Users.Add(entity);
            context.SaveChanges();
            return user.Entity;

        }

        User IRepository<User>.Update(User item)
        {
            validations.ValidateAndThrow(item);
            context.Users.Entry(context.Users.Find(item.Id)).CurrentValues
                   .SetValues(item);
            context.SaveChanges();
            return item;

        }
    }
}
