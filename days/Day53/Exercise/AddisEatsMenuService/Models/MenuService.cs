namespace AddisEatsMenuService.Models
{
    public record MenuItem(int Id, string Name, string Category, decimal Price);

    public interface IDiscountPolicy
    {
        decimal ApplyDiscount(decimal orginalPrice);
    }

    class TenPercentDiscount : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal orginalPrice)
        {
            return orginalPrice - (orginalPrice * 0.1m);
        }
    }

    class FiftyPercentDiscount : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal orginalPrice)
        {
            return (orginalPrice - (orginalPrice * 0.5m));
        }
    }

    class MenuService
    {
       private readonly List<MenuItem> _items = new List<MenuItem> {
            new MenuItem(1, "Doro Wote", "Main dish", 500m),
            new MenuItem(2, "Tibs", "Main dish", 400m),
            new MenuItem(3, "Dulet", "Main dish", 300m)
        };

        public void Add(MenuItem item)
        {
            if (item.Price <= 0)
            {
                throw new ArgumentException("Price must be grater than zero", nameof(item));
            }
            _items.Add(item);
        }

        public IReadOnlyList<MenuItem> GetAll() => _items.AsReadOnly();

        public List<MenuItem> GetByCategory (string category)
        {
            return _items.Where(x => x.Category == category).OrderBy(x=> x.Price).ToList();
        }

        public string? GetTotalAverageOf(string category)
        {
            List<MenuItem> itemsToBePerform = _items.Where(o => o.Category == category).ToList();
            if (itemsToBePerform.Count == 0)
            {
                return $"No items in {category}";
            }
            decimal average = itemsToBePerform.Average(x=> x.Price);
            decimal sum = itemsToBePerform.Sum(x=> x.Price);
            return $"the Sum: {sum}, Average: {average}";
        }
    }
}