using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using ClothingSalesControlSystem.Services.Interfaces;

namespace ClothingSalesControlSystem.Services.DefaultImplementations
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITShirtRepository _tShirtRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IUserRepository userRepository,
            ITShirtRepository tShirtRepository,
            IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _tShirtRepository = tShirtRepository;
            _orderRepository = orderRepository;
        }


        public async Task CreateOrder(int userId)
        {
            Console.WriteLine("Введіть номер футболки який ви хочете замовити: ");
            int tshirtId;
            bool isValidTshirtId = int.TryParse(Console.ReadLine(), out tshirtId);
            if (!isValidTshirtId)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не вірно введений номер футболки. Спробуйте ще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var user = await _userRepository.GetByIdAsync(userId);
            var tshirt = await _tShirtRepository.GetByIdAsync(tshirtId);
            if(user == null || tshirt == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tФутболок чи користувача не знайдено =(");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Order order = new Order()
            {
                UserId = userId,
                TShirtId = tshirtId,
                OrderDate = DateTime.Now,
                OrderPrice = tshirt.Price
            };
            
            await _orderRepository.AddAsync(order);
            if (order == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tЗамовлення не створено =(");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t\tЗамовлення успішно створено. Дякуємо =)");
                Console.ForegroundColor = ConsoleColor.White;
            }            
        }
    }
}
