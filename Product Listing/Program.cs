using System;
using System.Collections.Generic;
using System.Linq;

class Product
{

    private string NameOfProduct;
    private double CostOfProduct; 
    private int QuantityOfProduct;

    public string Name
    {
        get {return NameOfProduct;}
        set {NameOfProduct = value;}
    }
    public double Cost
    {
        get { return CostOfProduct; }
        set { CostOfProduct = value; }
    }
    public int Quantity
    {
        get{ return QuantityOfProduct;}
        set{ QuantityOfProduct = value;}
    }
    
    public double TotalCostOfItems
    {
        get {return CostOfProduct * QuantityOfProduct;}
    }

    public Product(string name, double cost, int quantity)
    {
      Name = name;
      Cost = cost; 
      Quantity = quantity;   
      
    }
}

class Category
{
    public string Name { get; set; }
    public List<Product> Products {get; set;}

    public Category(string name)
    {
        Name = name;
        Products = new List<Product>();
    }

    public void AddingProduct(Product product)
    {
        Products.Add(product);
    }
    
    public int TotalNumberOfItems()
    {
        return Products.Sum(p => p.Quantity);
    }

    public double TotalCostOfItems()
    {
        return Products.Sum(p => p.TotalCostOfItems);
    }
    
    public List<string> GetItemsName()
    {  
      
      return Products.Select(p => p.Name).ToList();
    }
    
    class Store
    {
        private List<Category> Categories;
        public Store()
      {
        Categories = new List<Category>
        {
            new Category("Fruit & Vegetable"),
            new Category("Bakery"),
            new Category("Dairy")
        };
      }  
        public void AddingProduct()
      {
        
        Console.WriteLine("Please select product category");
        for (int i = 0; i < Categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Categories[i].Name}");
        }
        Console.WriteLine("Category selected is: ");
        int categorySelected = Convert.ToInt32(Console.ReadLine()) - 1;

        if (categorySelected < 0 || categorySelected >= Categories.Count)
        {
            Console.WriteLine("Invalid category");
            return;
        }
        
        Console.WriteLine("Enter name of product: ");
        var name = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Enter cost of one unit: ");
        double cost = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter quantity of product: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Product product = new Product(name, cost, quantity);
        Categories[categorySelected].AddingProduct(product);

        Console.WriteLine("Product has been added successfully. \n");
      
    }

    public void ListingProducts()
    {
        Console.WriteLine("Please select category");
        for (int i = 0; i < Categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Categories[i].Name}");
        }
        Console.WriteLine($"{Categories.Count + 1}.All");

        Console.WriteLine("Selected category: ");
        int categorySelected = Convert.ToInt32(Console.ReadLine()) - 1;

        if (categorySelected == Categories.Count)
        {
            foreach(var category in Categories)
            {
                DisplayCategoryDetails(category);
            }
        }
        else if (categorySelected >= 0 && categorySelected < Categories.Count)
        {
            DisplayCategoryDetails(Categories[categorySelected]);
        }
        else 
        {
            Console.WriteLine("Invalid input, Try again!!!!");
        }
    }
    private void DisplayCategoryDetails(Category category)
    {
        Console.WriteLine($"\nSelected Category: {category.Name}");
        Console.WriteLine($"Total number of items: {category.TotalNumberOfItems()}");
        Console.WriteLine($"Items name:{string.Join(",", category.GetItemsName())}");
        Console.WriteLine($"Total cost of items: {category.TotalCostOfItems()}\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();
        bool ProgramRunning = true;



        while (ProgramRunning)
        {
            Console.WriteLine("Choose an opition below: ");
            Console.WriteLine("1. List of product");
            Console.WriteLine("2. List product details");
            Console.WriteLine("3. Exit the program");
            Console.WriteLine("Enter your Choice from 1 to 3");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                store.AddingProduct();
                break;
                
                case 2: 
                store.ListingProducts();
                break;

                case 3: 
                 ProgramRunning = false;
                 break;
                
                default: 
                Console.WriteLine("Invalid opition! enter from 1 to 3 only!!!!");
                break;
            }
        }
    }
  }
}