namespace ClothingSalesControlSystem.Services.Interfaces
{
    public interface IManagerService
    {
        Task ShowUsers();
        Task ShowOrders();
        Task ShowTShirts();
        Task UpdateTShirt();
        Task CreateTShirt();
        Task DeleteTShirt();
    }
}
