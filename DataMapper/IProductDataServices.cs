using DomainModel.Entity;

namespace DataMapper;

public interface IProductDataServices : IRepository<Product>
{
    IEnumerable<string> GetUserProductDescriptions(int userId);
    
    int GetActiveUserProductsCount(int userId);
}