using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using ClothingSalesControlSystem.Services.Interfaces;

namespace ClothingSalesControlSystem
{
    public class Startup
    {
        public User user { get; set; }
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly ITShirtService _tShirtService;
        private readonly IManagerService _managerService;


        public Startup(IUserRepository userRepository, 
            IUserService userService,
            IOrderService orderService,
            ITShirtService tShirtService,
            IManagerService managerService)
        {
            user = new User();
            _userRepository = userRepository;
            _userService = userService;
            _orderService = orderService;
            _tShirtService = tShirtService;
            _managerService = managerService;
        }

        public async Task RunAsUser()
        {
            while (true)
            {
                if(user.Id == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\t\t Welcome to the Clothing Sales Console App!\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    user = await _userService.Login();
                }

                DisplayUserOptions();
                int option;
                bool isValidOption = int.TryParse(Console.ReadLine(), out option);
                if (!isValidOption || option < 0 || option > 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                //Оновлення даних для користувача
                user = await _userRepository.GetUserByPhoneNumberAsync(user.Phone);

                switch (option)
                {
                    case 1:
                        await _userService.ShowUserInfo(user);                        
                        break;                                      
                    case 2:
                        await _userService.ShowUserOrders(user.Id);
                        break;                   
                    case 3:
                        await _userService.ShowTShirts();
                        break;                  
                    case 4:                       
                        await _orderService.CreateOrder(user.Id);                        
                        break;                  
                    case 5:
                        await _userService.ShowExpenses(user.Id);                       
                        break;
                    case 6:
                        await _tShirtService.GetTShirts();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Thank you for using the Clothing Sales Console App!");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                }
            }
        }
        
        public async Task RunAsManager()
        {
            while(true)
            {
                DisplayManagerOptions();
                int option;
                bool isValidOption = int.TryParse(Console.ReadLine(), out option);
                if (!isValidOption || option < 0 || option > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                switch (option)
                {
                    case 1:
                        await _managerService.ShowUsers();
                        break;
                    case 2:
                        await _managerService.ShowOrders();
                        break;
                    case 3:
                        await _managerService.ShowTShirts();
                        break;
                    case 4:
                        await _managerService.UpdateTShirt();
                        break;
                    case 5:
                        await _managerService.CreateTShirt();
                        break;
                    case 6:
                        await _managerService.DeleteTShirt();
                        break;
                    case 7:
                        await _tShirtService.GetTShirts();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Thank you for using the Clothing Sales Console App!");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                }
            }
        }

        public void DisplayUserOptions()
        {
            Console.WriteLine("1. Переглянути мою інформацію");
            Console.WriteLine("2. Переглянути мої замовлення");
            Console.WriteLine("3. Переглянути футболки");
            Console.WriteLine("4. Зробити замовлення");
            Console.WriteLine("5. Сума витрачених грошей");
            Console.WriteLine("6. Пошук футболок");
            Console.WriteLine("0. Вийти");

            Console.WriteLine("Виберіть опцію (введіть число від 1 до 6):");
        }

        public void DisplayManagerOptions()
        {
            Console.WriteLine("1. Переглянути всіх користувачів");
            Console.WriteLine("2. Переглянути всіх замовлень");
            Console.WriteLine("3. Переглянути всі футболки");
            Console.WriteLine("4. Змінити футболку");
            Console.WriteLine("5. Додати футболку");
            Console.WriteLine("6. Видалити футболку");
            Console.WriteLine("7. Пошук футболок");
            Console.WriteLine("0. Вийти");

            Console.WriteLine("Виберіть опцію (введіть число від 1 до 6):");
        }
    }
}
