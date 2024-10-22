using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public override string ToString()
    {
        return $"{name} (ID: {productId})";
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public override string ToString()
    {
        return $"{name}\n{address}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        double shippingCost = customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += product.ToString() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return customer.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");

        // Primeiro pedido
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W123", 10.0, 2));
        order1.AddProduct(new Product("Gadget", "G456", 15.0, 1));

        Console.WriteLine("Packing Label for Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label for Order 1:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nTotal Cost for Order 1:");
        Console.WriteLine(order1.GetTotalCost());

        // Segundo pedido
        Address address2 = new Address("456 Elm St", "Othertown", "TX", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Thingamajig", "T789", 20.0, 3));
        order2.AddProduct(new Product("Doodad", "D012", 25.0, 2));

        Console.WriteLine("\nPacking Label for Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label for Order 2:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\nTotal Cost for Order 2:");
        Console.WriteLine(order2.GetTotalCost());
    }
}
