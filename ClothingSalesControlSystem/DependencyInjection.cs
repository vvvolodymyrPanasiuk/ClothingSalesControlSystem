using ClothingSalesControlSystem.DAL.EF.Repositories;
using ClothingSalesControlSystem.DAL.EF;
using ClothingSalesControlSystem.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ClothingSalesControlSystem.Services.Interfaces;
using ClothingSalesControlSystem.Services.DefaultImplementations;

namespace ClothingSalesControlSystem
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Реєстрація іншого необхідного сервісу або контексту БД
            services.AddScoped<ClothingSalesDbContext>();

            // Реєстрація репозиторіїв та додавання їх залежностей
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITShirtRepository, TShirtRepository>(); 
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IUserService, UserService>(); 
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITShirtService, TShirtService>();
            services.AddScoped<IManagerService, ManagerService>();


            // Реєстрація класу Startup
            services.AddScoped<Startup>();
        }
    }
}
