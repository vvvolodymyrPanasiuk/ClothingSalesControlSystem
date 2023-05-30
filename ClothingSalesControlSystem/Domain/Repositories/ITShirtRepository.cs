using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;

namespace ClothingSalesControlSystem.Domain.Repositories
{
    public interface ITShirtRepository
    {
        IQueryable<TShirt> GetAll();
        Task<TShirt> GetByIdAsync(int id);
        Task AddAsync(TShirt tShirt);
        Task UpdateAsync(TShirt tShirt);
        Task DeleteAsync(TShirt tShirt);

        IQueryable<TShirt> GetTShirtsByType(TypeTShirt type);
        IQueryable<TShirt> GetTShirtsByColor(string color);
        IQueryable<TShirt> GetTShirtsByMaterial(string material);
        IQueryable<TShirt> GetTShirtsByPrint(string print);
        IQueryable<TShirt> GetTShirtsByPriceRange(decimal minPrice, decimal maxPrice);
        IQueryable<TShirt> SearchTShirtsByName(string name);
        IQueryable<TShirt> SortTShirtsByPriceAscending();
        IQueryable<TShirt> SortTShirtsByPriceDescending();
        IQueryable<TShirt> GetTShirtsByTypeColorMaterialPrint(TypeTShirt type, string color, string material, string print);
    }
}
