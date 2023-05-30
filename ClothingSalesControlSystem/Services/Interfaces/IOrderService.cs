using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;

namespace ClothingSalesControlSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(int userId);
    }
}
