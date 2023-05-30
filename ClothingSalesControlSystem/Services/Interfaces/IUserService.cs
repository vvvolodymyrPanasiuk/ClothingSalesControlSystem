using ClothingSalesControlSystem.Domain.Entities.UserAggregate;

namespace ClothingSalesControlSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Login();
        Task ShowUserInfo(User user);
        Task ShowUserOrders(int userId);
        Task ShowTShirts();
        Task ShowExpenses(int userId);
    }
}
