
class ShoppingCart
{
    private List<Product> products = new List<Product>();
    public IReadOnlyCollection<Product> Products => products.AsReadOnly();

    public void AddProduct(Product product)
    {
        if (product != null)
        {
            products.Add(product);
        }
    }

    public void RemoveProduct(Product product)
    {
        if (product != null && products.Contains(product))
        {
            products.Remove(product);
        }
    }

    public int GetTotalQuantity()
    {
        return products.Count;
    }

    public decimal GetTotalCost()
    {
        return products.Sum(p => p.Price);
    }
}
class CartDisplay
{
    public void DisplayCart(ShoppingCart cart)
    {
        Console.WriteLine("Your Shopping Cart:");
        foreach (var product in cart.Products)
        {
            Console.WriteLine($"- {product.Name}: ${product.Price}");
        }
        Console.WriteLine($"Total: ${cart.GetTotalCost()}");
    }

    public void ExportCartToFile(ShoppingCart cart, string filePath)
    {

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Shopping Cart:");
            foreach (var product in cart.Products)
            {
                writer.WriteLine($"- {product.Name}: ${product.Price}");
            }
            writer.WriteLine($"Total: ${cart.GetTotalCost()}");
        }
    }
}
class CartRepository
{
    public void SaveCart(ShoppingCart cart)
    {

        Console.WriteLine("Cart has been saved to the database.");
    }

    public ShoppingCart LoadCart(int cartId)
    {

        Console.WriteLine($"Loading cart with ID: {cartId}");
        return new ShoppingCart();
    }

    public void UpdateCart(ShoppingCart cart)
    {

        Console.WriteLine("Cart has been updated.");
    }

    public void DeleteCart(int cartId)
    {

        Console.WriteLine($"Cart with ID {cartId} has been deleted.");
    }
}
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
class Program
{
    static void Main(string[] args)
    {

        var cart = new ShoppingCart();
        var display = new CartDisplay();
        var repository = new CartRepository();

        cart.AddProduct(new Product("Laptop", 1200.00m));
        cart.AddProduct(new Product("Mouse", 25.00m));
        cart.AddProduct(new Product("Keyboard", 45.00m));


        display.DisplayCart(cart);

        repository.SaveCart(cart);

        Console.WriteLine("Operation complete. Press any key to exit.");
        Console.ReadKey();
    }
}