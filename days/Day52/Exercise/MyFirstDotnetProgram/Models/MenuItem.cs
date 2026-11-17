namespace MyFirstDotnetProgram.Models
{
    public class MenuItem
    {
        // Constructor to initialize a MenuItem object with the specified properties
        public MenuItem(int id, string name, string category, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithVAT => Price * 1.2m;
    }

}