using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClothingSalesControlSystem.DAL.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ClothingSalesDbContext _dbContext;

        public OrderRepository(ClothingSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Order> GetAll()
        {
            return _dbContext.Orders.AsQueryable();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetOrderCountForTShirtAsync(int tShirtId)
        {
            return await _dbContext.Orders.CountAsync(o => o.TShirtId == tShirtId);
        }

        public async Task<int> GetOrderCountForUserAsync(int userId)
        {
            return await _dbContext.Orders.CountAsync(o => o.UserId == userId);
        }

        public async Task<int> GetOrderCountByDay(int day)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            DateTime endDate = startDate.AddDays(1);

            return await _dbContext.Orders.CountAsync(o => o.OrderDate >= startDate && o.OrderDate < endDate);
        }

        public async Task<int> GetOrderCountByMonth(int month)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, month, 1);
            DateTime endDate = startDate.AddMonths(1);

            return await _dbContext.Orders.CountAsync(o => o.OrderDate >= startDate && o.OrderDate < endDate);
        }

        public async Task<int> GetOrderCountByYear(int year)
        {
            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = startDate.AddYears(1);

            return await _dbContext.Orders.CountAsync(o => o.OrderDate >= startDate && o.OrderDate < endDate);
        }

        public IQueryable<Order> GetOrdersByUserId(int userId)
        {
            return _dbContext.Orders.Where(o => o.UserId == userId);
        }

        public IQueryable<Order> GetOrdersByTShirtId(int tShirtId)
        {
            return _dbContext.Orders.Where(o => o.TShirtId == tShirtId);
        }

        public IQueryable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate);
        }

        public IQueryable<Order> GetOrdersByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _dbContext.Orders.Where(o => o.OrderPrice >= minPrice && o.OrderPrice <= maxPrice);
        }

        public async Task<int> GetOrderCountByTShirtId(int tShirtId)
        {
            return await _dbContext.Orders.CountAsync(o => o.TShirtId == tShirtId);
        }

        public async Task<int> GetOrderCountByUserId(int userId)
        {
            return await _dbContext.Orders.CountAsync(o => o.UserId == userId);
        }
    }
}
