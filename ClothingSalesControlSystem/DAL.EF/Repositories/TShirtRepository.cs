using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using System.Drawing;

namespace ClothingSalesControlSystem.DAL.EF.Repositories
{
    public class TShirtRepository : ITShirtRepository
    {
        private readonly ClothingSalesDbContext _dbContext;

        public TShirtRepository(ClothingSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TShirt> GetAll()
        {
            return _dbContext.TShirts.AsQueryable();
        }

        public async Task<TShirt> GetByIdAsync(int id)
        {
            return await _dbContext.TShirts.FindAsync(id);
        }

        public async Task AddAsync(TShirt tShirt)
        {
            await _dbContext.TShirts.AddAsync(tShirt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TShirt tShirt)
        {
            _dbContext.TShirts.Update(tShirt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TShirt tShirt)
        {
            _dbContext.TShirts.Remove(tShirt);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TShirt> GetTShirtsSortedByPriceAscending()
        {
            return _dbContext.TShirts.OrderBy(t => t.Price);
        }

        public IQueryable<TShirt> GetTShirtsSortedByPriceDescending()
        {
            return _dbContext.TShirts.OrderByDescending(t => t.Price);
        }

        public IQueryable<TShirt> GetTShirtsByColor(string color)
        {
            return _dbContext.TShirts.Where(t => t.Color == color);
        }

        public IQueryable<TShirt> GetTShirtsWithPrints()
        {
            return _dbContext.TShirts.Where(t => !string.IsNullOrEmpty(t.Print));
        }

        public IQueryable<TShirt> GetTShirtsByType(TypeTShirt type)
        {
            return _dbContext.TShirts.Where(t => t.Type == type);
        }

        public IQueryable<TShirt> GetTShirtsByMaterial(string material)
        {
            return _dbContext.TShirts.Where(t => t.Material == material);
        }

        public IQueryable<TShirt> GetTShirtsByPrint(string print)
        {
            return _dbContext.TShirts.Where(t => t.Print == print);
        }

        public IQueryable<TShirt> GetTShirtsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _dbContext.TShirts.Where(t => t.Price >= minPrice && t.Price <= maxPrice);
        }

        public IQueryable<TShirt> SearchTShirtsByName(string name)
        {
            return _dbContext.TShirts.Where(t => t.Name.Contains(name));
        }

        public IQueryable<TShirt> SortTShirtsByPriceAscending()
        {
            return _dbContext.TShirts.OrderBy(t => t.Price);
        }

        public IQueryable<TShirt> SortTShirtsByPriceDescending()
        {
            return _dbContext.TShirts.OrderByDescending(t => t.Price);
        }

        public IQueryable<TShirt> GetTShirtsByTypeColorMaterialPrint(TypeTShirt type, string color, string material, string print)
        {
            return _dbContext.TShirts.Where(t =>
                        t.Type == type &&
                        t.Color == color &&
                        t.Material == material &&
                        t.Print == print);
        }
    }
}
