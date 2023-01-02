using DomainModel;

namespace DataMapper.PostgresDAO
{
    public class PostgresUserDataServices : IUserDataServices
    {
        private readonly AuctionAppContext context;

        public PostgresUserDataServices(AuctionAppContext context)
        {
            this.context = context;
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
            throw new NotImplementedException();
        }

        User IRepository<User>.Insert(User entity)
        {
            throw new NotImplementedException();
        }

        User IRepository<User>.Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
