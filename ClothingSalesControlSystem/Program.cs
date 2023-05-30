using ClothingSalesControlSystem.DAL.EF.Repositories;
using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace ClothingSalesControlSystem
{
    internal class Program
    {
        const string ADMIN_CODE = "Admin123";

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8; // на всякий випадок

            // Конфігурація сервісів DI
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            // Побудова провайдера сервісів
            var serviceProvider = services.BuildServiceProvider();
            // Отримання інстанції класу Startup з провайдера сервісів
            Startup startup = serviceProvider.GetService<Startup>();
            if(startup == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Server error =(");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }

            // Запуск з класу Startup
            while (true)
            {
                int role;
                Console.WriteLine("\tSelect your role: \n" +
                    "1 - Manager\n" +
                    "2 - User\n" +
                    "0 - Exit\n");
                
                bool isValidRole = int.TryParse(Console.ReadLine(), out role);               
                if (!isValidRole || role < 0 || role > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tНевірна опція. Спробуйте ще раз.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                switch (role)
                {
                    case 1:                       
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Admin code: ");
                        string userCode = Console.ReadLine();
                        if(userCode == ADMIN_CODE)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            await startup.RunAsManager();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\tWrong code!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 2:
                        await startup.RunAsUser();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\tPAPA =)");
                        return;
                }
            }
        }
    }
}