using DomainModel;

namespace DataMapper.PostgresDAO
{
    public class PostgresUserDataServices : IUserDataServices
    {
        private readonly AuctionAppContext _context;

        public PostgresUserDataServices(AuctionAppContext context)
        {
            this._context = context;
        }

        void IRepository<User>.Delete(User entity)
        {
            var userAccount = _context.Users.Find(entity.Id);
            if (userAccount == null)
                return;

            _context.Users.Remove(userAccount);
            _context.SaveChanges();
        }

        IList<User> IRepository<User>.GetAll()
        {
            return _context.Users.ToList();
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
