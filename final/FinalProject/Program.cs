using System;
using System.Collections.Generic;


public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    public Product(string name, double price, int initialQuantity)
    {
        Name = name;
        Price = price;
        QuantityInStock = initialQuantity;
    }

    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }
}


public class Inventory
{
    public List<Product> Products { get; private set; }

    public Inventory()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product newProduct)
    {
        Products.Add(newProduct);
    }

    public void DisplayProducts()
    {
        Console.WriteLine("Inventory:");
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name} - Price: ${product.Price} - Quantity: {product.QuantityInStock}");
        }
    }
}


public class Sales
{
    private Inventory inventory;

    public Sales(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void RecordSale(Product product, int quantitySold)
    {
        if (product.QuantityInStock >= quantitySold)
        {
            product.QuantityInStock -= quantitySold;
            Console.WriteLine($"Sale recorded: {quantitySold} {product.Name}(s).");
        }
        else
        {
            Console.WriteLine("Error: Insufficient stock for the sale.");
        }
    }
}


public class UserInterface
{
    private Inventory inventory;
    private Sales salesSystem;

    public UserInterface(Inventory inventory, Sales salesSystem)
    {
        this.inventory = inventory;
        this.salesSystem = salesSystem;
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Record Sale");
        Console.WriteLine("3. Display Inventory");
        Console.WriteLine("4. Exit");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                AddProduct();
                break;
            case 2:
                RecordSale();
                break;
            case 3:
                inventory.DisplayProducts();
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private void AddProduct()
    {
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter product price:");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter initial quantity in stock:");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Product newProduct = new Product(name, price, quantity);
        inventory.AddProduct(newProduct);

        Console.WriteLine("Product added successfully.");
    }

    private void RecordSale()
    {
        Console.WriteLine("Enter product name for sale:");
        string name = Console.ReadLine();

        Product product = inventory.Products.Find(p => p.Name == name);

        if (product == null)
        {
            Console.WriteLine("Error: Product not found.");
        }
        else
        {
            Console.WriteLine("Enter quantity sold:");
            int quantitySold = Convert.ToInt32(Console.ReadLine());

            salesSystem.RecordSale(product, quantitySold);
        }
    }
}

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();
        Sales sales = new Sales(inventory);
        UserInterface ui = new UserInterface(inventory, sales);

        while (true)
        {
            ui.ShowMainMenu();
        }
    }
}
