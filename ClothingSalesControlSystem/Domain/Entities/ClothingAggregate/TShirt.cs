namespace ClothingSalesControlSystem.Domain.Entities.ClothingAggregate
{
    public enum TypeTShirt
    {
        Standart = 1,
        Polo = 2,
        Longsleeve = 3,
        Singlet = 4
    }
    public class TShirt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string? Print { get; set; }
        public TypeTShirt Type { get; set; }
    }
}
