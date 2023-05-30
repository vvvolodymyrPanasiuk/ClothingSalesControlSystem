using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Entities.UserAggregate;

namespace ClothingSalesControlSystem.Domain.Entities.OrderAggregate
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TShirtId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }

        public User User { get; set; }
        public TShirt TShirt { get; set; }
    }
}
