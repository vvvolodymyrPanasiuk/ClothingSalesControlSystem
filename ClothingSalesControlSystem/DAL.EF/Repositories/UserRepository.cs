using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClothingSalesControlSystem.DAL.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClothingSalesDbContext _dbContext;

        public UserRepository(ClothingSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users.AsQueryable();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetUserCountInCountry(string country)
        {
            return await _dbContext.Users.CountAsync(u => u.Country == country);
        }

        public async Task<int> GetUserCountInCity(string city)
        {
            return await _dbContext.Users.CountAsync(u => u.City == city);
        }

        public IQueryable<User> GetUsersSortedByName()
        {
            return _dbContext.Users.OrderBy(u => u.SecondName).ThenBy(u => u.FirstName);
        }

        public IQueryable<User> GetUsersByCountry(string country)
        {
            return _dbContext.Users.Where(u => u.Country == country);
        }

        public IQueryable<User> GetUsersByCity(string city)
        {
            return _dbContext.Users.Where(u => u.City == city);
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Phone == phoneNumber);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public IQueryable<User> SearchUsersByLastName(string lastName)
        {
            return _dbContext.Users.Where(u => u.SecondName.Contains(lastName));
        }

        public IQueryable<User> SearchUsersByFullName(string firstName, string lastName)
        {
            return _dbContext.Users.Where(u => u.FirstName.Contains(firstName) && u.SecondName.Contains(lastName));
        }

        public async Task<int> GetUsersCountByCountryAsync(string country)
        {
            return await _dbContext.Users.CountAsync(u => u.Country == country);
        }

        public async Task<int> GetUsersCountByCityAsync(string city)
        {
            return await _dbContext.Users.CountAsync(u => u.City == city);
        }

        public IQueryable<User> GetUsersSortedByLastName()
        {
            return _dbContext.Users.OrderBy(u => u.SecondName);
        }

        public IQueryable<User> GetUsersSortedByFullName()
        {
            return _dbContext.Users.OrderBy(u => u.SecondName).ThenBy(u => u.FirstName);
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Phone == phoneNumber);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
