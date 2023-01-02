using DomainModel.Enum;

namespace DomainModel.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerId { get; set; }
        public Currency Currency { get; set; }
        public virtual IList<AuctionDto>? Offers { get; set; }

        public class AuctionDto
        {
            public ProductDto ProductDto { get; }
            public int Id { get; set; }
            public decimal Price { get; set; }
            public AuctionDto() { }

            public AuctionDto(ProductDto product)
            {
                ProductDto = product;
            }
        }
    }
}
