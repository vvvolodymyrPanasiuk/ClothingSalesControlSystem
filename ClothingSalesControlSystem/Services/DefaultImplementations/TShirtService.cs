using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using ClothingSalesControlSystem.Domain.Repositories;
using ClothingSalesControlSystem.Services.Interfaces;

namespace ClothingSalesControlSystem.Services.DefaultImplementations
{
    public class TShirtService : ITShirtService
    {
        private readonly ITShirtRepository _tShirtRepository;

        public TShirtService(ITShirtRepository tShirtRepository)
        {
            _tShirtRepository = tShirtRepository;
        }

        public void DisplayTShirtsOptions()
        {
            Console.WriteLine("1. Вивести футболки від найдешевших");
            Console.WriteLine("2. Вивести футболки від найдорощих");
            Console.WriteLine("3. Вивести футболки по типу");
            Console.WriteLine("4. Вивести футболки по назві");
            Console.WriteLine("5. Вивести футболки по кольору");
            Console.WriteLine("6. Вивести футболки по матеріалу");
            Console.WriteLine("7. Вивести футболки по принту");
            Console.WriteLine("8. Вивести футболки по всіх параметрах");

            Console.WriteLine("0. Вийти");
            Console.WriteLine("Виберіть опцію (введіть число від 1 до 5):");

        }

        public void ShowTShirts(IEnumerable<TShirt> tshirts)
        {
            if (tshirts == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\t\tФутболки не знайдено =( ");
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

        public async Task GetTShirts()
        {
            while(true)
            {
                DisplayTShirtsOptions();
                int option;
                bool isValidOption = int.TryParse(Console.ReadLine(), out option);
                if (!isValidOption || option < 0 || option > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n\t\t\tВід найдешевших\n");
                        ShowTShirts(_tShirtRepository.SortTShirtsByPriceDescending());                      
                        break;
                    
                    case 2:
                        Console.WriteLine("\n\t\t\tВід найдорощих\n");
                        ShowTShirts(_tShirtRepository.SortTShirtsByPriceAscending()); 
                        break;                       
                    
                    case 3:
                        Console.WriteLine("\n\t\t\tПо типу\n");
                        Console.WriteLine("\n\tВиберіть тип із (число): " +
                            "1. Standart" +
                            "2. Polo" +
                            "3. Longsleeve" +
                            "4. Singlet" +
                            "\n");
                        int type = int.Parse(Console.ReadLine());                       
                        ShowTShirts(_tShirtRepository.GetTShirtsByType((TypeTShirt)type));
                        break;
                    
                    case 4:
                        Console.WriteLine("\n\t\t\tПо назві\n");
                        Console.WriteLine("\n\tВедіть назву футболки яку шукаєте");
                        ShowTShirts(_tShirtRepository.SearchTShirtsByName(Console.ReadLine()));
                        break;
                    
                    case 5:
                        Console.WriteLine("\n\t\t\tПо кольору\n");
                        Console.WriteLine("\n\tВедіть назву кольору футболки яку шукаєте");
                        ShowTShirts(_tShirtRepository.GetTShirtsByColor(Console.ReadLine()));
                        break;
                    
                    case 6:
                        Console.WriteLine("\n\t\t\tПо матеріалу\n");
                        Console.WriteLine("\n\tВедіть назву матеріалу футболки яку шукаєте");
                        ShowTShirts(_tShirtRepository.GetTShirtsByMaterial(Console.ReadLine()));
                        break;
                    
                    case 7:
                        Console.WriteLine("\n\t\t\tПо принту\n");
                        Console.WriteLine("\n\tВедіть назву принту футболки яку шукаєте");
                        ShowTShirts(_tShirtRepository.GetTShirtsByPrint(Console.ReadLine()));
                        break;
                    
                    case 8:
                        Console.WriteLine("\n\t\t\t8. Вивести футболки по всіх параметрах\n");
                        Console.WriteLine("\n\tВиберіть тип із (число): " +
                            "1. Standart" +
                            "2. Polo" +
                            "3. Longsleeve" +
                            "4. Singlet" +
                            "\n");
                        int type1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("\n\tВедіть назву кольору футболки яку шукаєте");
                        string color = Console.ReadLine();

                        Console.WriteLine("\n\tВедіть назву матеріалу футболки яку шукаєте");
                        string material = Console.ReadLine();

                        Console.WriteLine("\n\tВедіть назву принту футболки яку шукаєте");
                        string print = Console.ReadLine();

                        ShowTShirts(_tShirtRepository
                            .GetTShirtsByTypeColorMaterialPrint((TypeTShirt)type1, color, material, print));
                        break;
                    
                    case 0:
                        Console.WriteLine("\n\t\t\tЗнаходьте швидко та зручно із нами =)\n");
                        return;
                }
            }
        }
    }
}
