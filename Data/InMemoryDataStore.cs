using ECommerceApi.Entities;

public static class InMemoryDataStore
{
    private static int _productIdCounter = 0;
    private static int _userIdCounter = 0;
    private static int _orderIdCounter = 0;
    public static int GetNextProductId() => ++_productIdCounter;
    public static int GetNextUserId() => ++_userIdCounter;
    public static int GetNextOrderId() => ++_orderIdCounter;

    public static List<Product> Products { get; } = new List<Product>
    {
        new Product { Id = GetNextProductId(), Name = "Laptop", Price = 35000, Stock = 10 }, 
        new Product { Id = GetNextProductId(), Name = "Mouse", Price = 500, Stock = 50 },
        new Product { Id = GetNextProductId(), Name = "Klavye", Price = 1200, Stock = 25 },
        new Product { Id = GetNextProductId(), Name = "Webcam", Price = 800, Stock = 5 }
    };

    public static List<User> Users { get; } = new List<User>
    {
        new User { Id = GetNextUserId(), Name = "Burak Example", Email = "burak@example.com" },
        new User { Id = GetNextUserId(), Name = "Engin Example", Email = "engin@example.com" },
        new User { Id = GetNextUserId(), Name = "Zeynep Example", Email = "zeynep@example.com" }
    };

    public static List<Order> Orders { get; } = new List<Order>
    {
        new Order {
            Id = GetNextOrderId(),
            UserId = 2,
            ProductId = 1,
            Quantity = 1,
            TotalPrice = 35000 * 1,
            CreateDate = DateTime.UtcNow.AddHours(-5)
        },
        new Order {
            Id = GetNextOrderId(),
            UserId = 2,
            ProductId = 2,
            Quantity = 2,
            TotalPrice = 500 * 2,
            CreateDate = DateTime.UtcNow.AddHours(-3)
        },
        new Order {
            Id = GetNextOrderId(),
            UserId = 1,
            ProductId = 3,
            Quantity = 1,
            TotalPrice = 1200 * 1,
            CreateDate = DateTime.UtcNow.AddHours(-1)
        }
    };
}