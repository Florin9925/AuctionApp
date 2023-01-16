using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

namespace DataMapper.PostgresDAO
{
    public class PostgresCategoryDataServices : ICategoryDataServices
    {
        private readonly AuctionAppContext _context;
        private readonly CategoryValidator _validator;

        public PostgresCategoryDataServices(AuctionAppContext context, CategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        void IRepository<Category>.Delete(Category entity)
        {
            var category = _context.Categories.Find(entity.Id);
            if (category == null)
                return;

            _context.Remove(category);
            _context.SaveChanges();
        }

        IList<Category> IRepository<Category>.GetAll()
        {
            return _context.Categories.ToList();
        }

        Category IRepository<Category>.GetById(object id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return _context.Categories.Find(id);
        }

        Category IRepository<Category>.Insert(Category entity)
        {
            _validator.ValidateAndThrow(entity);
            var category = _context.Add(entity);
            _context.SaveChanges();
            return category.Entity;
        }

        Category IRepository<Category>.Update(Category item)
        {
            _validator.ValidateAndThrow(item);
            var entity = _context.Categories.Find(item.Id);

            ArgumentNullException.ThrowIfNull(entity);

            _context.Entry(entity).CurrentValues
                .SetValues(item);
            _context.SaveChanges();
            return item;
        }
    }
}