using ClothingSalesControlSystem.Domain.Entities.UserAggregate;

namespace ClothingSalesControlSystem.Domain.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);

        Task<int> GetUsersCountByCountryAsync(string country);
        Task<int> GetUsersCountByCityAsync(string city);
        IQueryable<User> GetUsersSortedByLastName();
        IQueryable<User> GetUsersSortedByFullName();
        IQueryable<User> GetUsersByCountry(string country);
        IQueryable<User> GetUsersByCity(string city);
        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<User> GetUserByEmailAsync(string email);
        IQueryable<User> SearchUsersByLastName(string lastName);
        IQueryable<User> SearchUsersByFullName(string firstName, string lastName);

    }
}
