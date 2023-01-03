using DomainModel.Enum;

namespace DomainModel.DTO
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerId { get; set; }
        public Currency Currency { get; set; }
    }
}