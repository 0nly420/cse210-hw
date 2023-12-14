
public class Product
{

    private string name;
    private double price;
    private int quantityInStock;


    public Product(string name, double price, int initialQuantity)
    {
        this.name = name;
        this.price = price;
        this.quantityInStock = initialQuantity;
    }


    public void UpdatePrice(double newPrice)
    {
        this.price = newPrice;
    }


}

public class Inventory
{

    private List<Product> products;


    public Inventory()
    {
        this.products = new List<Product>();
    }


    public void AddProduct(Product newProduct)
    {
        this.products.Add(newProduct);
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

    }


}
