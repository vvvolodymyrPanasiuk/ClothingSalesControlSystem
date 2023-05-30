using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;
using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using ClothingSalesControlSystem.Services.Interfaces;

namespace ClothingSalesControlSystem.Services.DefaultImplementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITShirtRepository _tShirtRepository;
        private readonly IOrderRepository _orderRepository;

        public UserService(IUserRepository userRepository,
            ITShirtRepository tShirtRepository,
            IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _tShirtRepository = tShirtRepository;
            _orderRepository = orderRepository;
        }

        public async Task<User> Login()
        {
            var user = new User();
            Console.WriteLine("Введіть ім'я: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Введіть фамілію: ");
            user.SecondName = Console.ReadLine();
            Console.WriteLine("Введіть номер телефону: ");
            user.Phone = Console.ReadLine();
            Console.WriteLine("Введіть електрону пошту (НЕ обов'язково): ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Введіть країні: ");
            user.Country = Console.ReadLine();
            Console.WriteLine("Введіть місто: ");
            user.City = Console.ReadLine();
            Console.WriteLine("Введіть адресу проживання: ");
            user.Address = Console.ReadLine();

            await _userRepository.AddAsync(user);
            User account = await _userRepository.GetUserByPhoneNumberAsync(user.Phone);
            if (account is not null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Вітаємо {account.FirstName} {account.SecondName}, Ви успішно зайшли! \n\n");
                Console.ForegroundColor = ConsoleColor.White;
                return account;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Щось пошло не так");
                Console.ForegroundColor = ConsoleColor.White;
                return new User();
            }
        }

        public async Task ShowExpenses(int userId)
        {
            var orders = _orderRepository.GetOrdersByUserId(userId);
            if (orders == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\t\tНемає замовлень =(");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            decimal sumOfOrders = 0;
            foreach (Order order in orders)
            {
                sumOfOrders = sumOfOrders + order.OrderPrice;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\t\tСума витрачених грошей на сайті: {sumOfOrders} ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public async Task ShowTShirts()
        {
            var tshirts = _tShirtRepository.GetAll();
            if (tshirts.Count() <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t\tФутболок ще немає =(");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("\nФутболбки: ");
            foreach (TShirt tshirt in tshirts)
            {
                Console.WriteLine($"\tФутболка номер - {tshirt.Id}: \n" +
                    $"\t\tНазва: {tshirt.Name} \n" +
                    $"\t\tТип/форма: {tshirt.Type} \n" +
                    $"\t\tРозмір: {tshirt.Size} \n" +
                    $"\t\tКолір: {tshirt.Color} \n" +
                    $"\t\tМатеріал: {tshirt.Material} \n" +
                    $"\t\tПрінт: {tshirt.Print} \n" +
                    $"\t\tЦіна: {tshirt.Price} \n");
                Console.WriteLine("\n\n");
            }
        }

        public async Task ShowUserInfo(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ІНФОРМАЦІЯ АККАУНТУ\n");
            Console.WriteLine($"Ім'я: {user.FirstName}\n" +
                $"\t\tФамілія: {user.SecondName}\n" +
                $"\t\tНомер телефону: {user.Phone}\n" +
                $"\t\tЕлектрона пошта: {user.Email}\n" +
                $"\t\tКріїна: {user.Country}\n" +
                $"\t\tМісто: {user.City}\n" +
                $"\t\tАдреса проживання: {user.Address}\n" +
                $"\t\tКількість замовлень: {await _orderRepository.GetOrderCountByUserId(user.Id)}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public async Task ShowUserOrders(int userId)
        {
            var orders = _orderRepository.GetOrdersByUserId(userId);
            if (orders.Count() <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\t\tНемає замовлень =( ");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("\nЗамовлення: ");
            foreach (Order order in orders)
            {
                Console.WriteLine($"\t\tНомер замовлення {order.Id}, " +
                    $"час: {order.OrderDate}, номер продукту: {order.TShirtId}, ціна: {order.OrderPrice}\n");
            }
        }
    }
}
