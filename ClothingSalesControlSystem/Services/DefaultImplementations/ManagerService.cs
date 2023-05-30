using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;
using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using ClothingSalesControlSystem.Services.Interfaces;

namespace ClothingSalesControlSystem.Services.DefaultImplementations
{
    public class ManagerService : IManagerService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITShirtRepository _tShirtRepository;
        private readonly IOrderRepository _orderRepository;

        public ManagerService(IUserRepository userRepository,
            ITShirtRepository tShirtRepository,
            IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _tShirtRepository = tShirtRepository;
            _orderRepository = orderRepository;
        }

        public async Task CreateTShirt()
        {
            Console.WriteLine("\n\tВедіть назву футболки");
            string name = Console.ReadLine();

            Console.WriteLine("\n\tВиберіть тип із (число): " +
                            "1. Standart" +
                            "2. Polo" +
                            "3. Longsleeve" +
                            "4. Singlet" +
                            "\n");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\tВедіть назву кольору футболки");
            string color = Console.ReadLine();

            Console.WriteLine("\n\tВедіть назву матеріалу футболки");
            string material = Console.ReadLine();

            Console.WriteLine("\n\tВедіть назву принту футболки");
            string print = Console.ReadLine();

            Console.WriteLine("\n\tВедіть розмір футболки");
            string size = Console.ReadLine();

            Console.WriteLine("\n\tВедіть ціну футболки");
            decimal price = decimal.Parse(Console.ReadLine());

            TShirt tshirt = new TShirt()
            {
                Name = name,
                Price = price,
                Size = size, 
                Print = print,
                Color = color,
                Material = material,
                Type = (TypeTShirt)type
            };

            await _tShirtRepository.AddAsync(tshirt);
            if (tshirt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tФутболка не добавлена");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\tФутболку успішно добавлено");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public async Task DeleteTShirt()
        {
            Console.WriteLine("\n\tВедіть номер футболки яку потрібно видалити");
            int tshirtId = int.Parse(Console.ReadLine());

            var tshirt = await _tShirtRepository.GetByIdAsync(tshirtId);
            if(tshirt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tФутболка не знайдена або не існує");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            await _tShirtRepository.DeleteAsync(tshirt);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tФутболку успішно видалено");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public async Task UpdateTShirt()
        {
            Console.WriteLine("\n\tВедіть номер футболки яку потрібно змінити");
            int tshirtId = int.Parse(Console.ReadLine());

            var tshirt = await _tShirtRepository.GetByIdAsync(tshirtId);
            if (tshirt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tФутболка не знайдена або не існує");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.WriteLine("\n\tВедіть оновлену назву футболки");
            string name = Console.ReadLine();

            Console.WriteLine("\n\tВиберіть оновлений тип із (число): " +
                            "1. Standart" +
                            "2. Polo" +
                            "3. Longsleeve" +
                            "4. Singlet" +
                            "\n");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\tВедіть оновлену назву кольору футболки");
            string color = Console.ReadLine();

            Console.WriteLine("\n\tВедіть оновлену назву матеріалу футболки");
            string material = Console.ReadLine();

            Console.WriteLine("\n\tВедіть оновлену назву принту футболки");
            string print = Console.ReadLine();

            Console.WriteLine("\n\tВедіть оновлений розмір футболки");
            string size = Console.ReadLine();

            Console.WriteLine("\n\tВедіть оновлену ціну футболки");
            decimal price = decimal.Parse(Console.ReadLine());

            TShirt tshirtForUpdating = new TShirt()
            {
                Id = tshirtId,
                Name = name,
                Price = price,
                Size = size,
                Print = print,
                Color = color,
                Material = material,
                Type = (TypeTShirt)type
            };

            await _tShirtRepository.UpdateAsync(tshirtForUpdating);
            if (tshirt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tФутболка не змінена");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\tФутболку успішно змінено");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public async Task ShowOrders()
        {
            var orders = _orderRepository.GetAll();
            if (orders == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t\tЗамовлень немає.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.WriteLine("\nЗамовлення: ");
            foreach (Order order in orders)
            {
                Console.WriteLine($"\t\tНомер замовлення {order.Id}, " +
                    $"час: {order.OrderDate}, " +
                    $"номер продукту: {order.TShirtId}, " +
                    $"ID корситвуча: {order.UserId}, " +
                    $"сума замовлення: {order.OrderPrice}\n");
            }
        }

        public async Task ShowTShirts()
        {
            var tshirts = _tShirtRepository.GetAll();
            if(tshirts == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t\tФутболок ще немає.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("\nФутболбки: ");
            foreach(TShirt tshirt in tshirts)
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

        public async Task ShowUsers()
        {
            var users = _userRepository.GetAll();
            if (users == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\t\tКористувачів немає.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("\tКористувачі: ");
            foreach(User user in users)
            {
                Console.WriteLine($"\tID користувача - {user.Id}: \n" +
                    $"\t\tІм'я: {user.FirstName} \n" +
                    $"\t\tТип/форма: {user.SecondName} \n" +
                    $"\t\tРозмір: {user.Email} \n" +
                    $"\t\tКолір: {user.Phone} \n" +
                    $"\t\tМатеріал: {user.Country} \n" +
                    $"\t\tПрінт: {user.City} \n" +
                    $"\t\tЦіна: {user.Address} \n" +
                    $"\t\tКількість замовлень: {await _orderRepository.GetOrderCountByUserId(user.Id)}\n");
                Console.WriteLine("\n\n");
            }
        }     
    }
}
