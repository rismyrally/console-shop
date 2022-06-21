using System;
using Models;
using Util;

namespace online_shop
{
  public class Shop
  {
    private List<Brand> _brands = new List<Brand>();
    private List<Product> _products = new List<Product>();
    private List<Discount> _discounts = new List<Discount>();
    private Cart _cart = new Cart();

    public Shop()
    {
      CreateProducts();
      CreateDiscounts();
    }


    private void CreateProducts()
    {
      var zara = new Brand(1, "Zara", "Germany");
      var tommy = new Brand(2, "Tommy Hilfiger", "Turkey");
      var chanel = new Brand(2, "Chanel", "Paris");
      var gucci = new Brand(2, "Gucci", "United Kingdom");
      var armani = new Brand(4, "Armani", "Italy");

      _brands.Add(zara);
      _brands.Add(tommy);
      _brands.Add(chanel);
      _brands.Add(gucci);
      _brands.Add(armani);

      _products = new List<Product>{
        new Product("1", "Jeans", 15, ProductSize.M, zara),
        new Product("2", "Chinos", 13.5M, ProductSize.S, tommy),
        new Product("3", "Polo T-Shirt", 12.35M, ProductSize.XS, chanel),
        new Product("4", "Modern Skirt", 12.25M, ProductSize.L, armani),
        new Product("5", "SS Shirt", 14.99M, ProductSize.M, gucci)
      };

    }

    private void CreateDiscounts()
    {
      _discounts.Add(new Discount("DISCOUNT25", 0.25M));
      _discounts.Add(new Discount("SAVE15", 0.15M));
      _discounts.Add(new Discount("FASHION20", 0.20M));
    }

    public void StartShopping()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("\nOnline Shopping Application\n");

        Console.WriteLine("[1] - Browse Products");
        Console.WriteLine("[2] - View Shopping Cart");
        Console.WriteLine("[0] - To exit application\n");
        Console.Write("Enter your option: ");
        var option = Console.ReadLine();

        switch (option)
        {
          case "0":
            Console.WriteLine("Exiting application..........");
            System.Environment.Exit(1);
            break;

          case "1":
            BrowseProducts();
            break;

          case "2":
            ViewShoppingCart();
            break;

          default:
            Logger.Error("Invalid option, press any key to try again");
            Console.ReadKey();
            break;
        }
      }
    }

    private void DisplayProducts()
    {
      Console.WriteLine("\n{0,-3} {1,-20} {2,-20} {3,-7} {4,-7}", "Id", "Brand", "Name", "Size", "Price");
      for (int i = 0; i <= 59; i++)
        Console.Write("-");
      Console.WriteLine("-");

      foreach (var product in _products)
      {
        product.PrintDetails();
      }
    }

    private bool AddItemToCart()
    {
      Console.Write("\nEnter the product Id you want to buy: ");
      var productId = Console.ReadLine();

      Product selectedProduct = _products.FirstOrDefault(product => product.ProductId == productId);

      if (selectedProduct != null)
      {
        _cart.AddProduct(selectedProduct);
        return true;
      }
      else
      {
        Logger.Warn("\nProduct not found, press any key to try again");
        Console.ReadKey();
        return false;
      }
    }

    private void BrowseProducts()
    {
      Console.Clear();
      DisplayProducts();
      bool success = AddItemToCart();
      string addMoreProducts = "";
      if (success)
      {
        Console.Write("\nDo you wish to add another product? [Y/N]: ");
        addMoreProducts = Console.ReadLine().ToUpper().Trim();
      }
      if (addMoreProducts == "Y" || !success)
      {
        BrowseProducts();
      }
    }

    private void ViewShoppingCart()
    {
      var border = "----------------------------";
      Console.Clear();

      if (_cart.IsEmpty())
      {
        Logger.Info("Your shopping cart is empty, press any key to go back");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("\n{0,-20} {1,-7}", "Product", "Price");
      Console.WriteLine(border);

      foreach (var product in _cart.Products)
      {
        Console.WriteLine("{0,-20} {1,7}", product.Name, StringFormat.Amount(product.Price));
      }

      Console.WriteLine(border);

      Console.WriteLine("{0,-20} {1,7}", "Discount", StringFormat.Amount(_cart.DiscountAmount));
      Console.WriteLine("{0,-20} {1,7}", "Total Cost", StringFormat.Amount(_cart.TotalCost));

      Console.ReadKey();
    }
  }
}
