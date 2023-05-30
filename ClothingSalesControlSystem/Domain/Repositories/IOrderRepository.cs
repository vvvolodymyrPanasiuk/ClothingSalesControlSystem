using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;

namespace ClothingSalesControlSystem.Domain.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);

        IQueryable<Order> GetOrdersByUserId(int userId);
        IQueryable<Order> GetOrdersByTShirtId(int tShirtId);
        IQueryable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        IQueryable<Order> GetOrdersByPriceRange(decimal minPrice, decimal maxPrice);
        Task<int> GetOrderCountByTShirtId(int tShirtId);
        Task<int> GetOrderCountByUserId(int userId);
        Task<int> GetOrderCountByDay(int day);
        Task<int> GetOrderCountByMonth(int month);
        Task<int> GetOrderCountByYear(int year);

    }
}
