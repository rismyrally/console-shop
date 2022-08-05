// PROJECT WORK         ONLINE CLOTHING STORE

// GROUP MEMBERS:
// ERSU CAGIL SEKERCAN                       // 3107988
// GEORGY IVANOV                             // 3107512
// MOHAMED IBRAHIM AHAMED MOHIDEEN MAHAROOF  // 3107589


using System;
using System.Collections.Generic;

namespace Project_Online_Store
{
  internal class ProgramCopy
  {
    static public List<Brand> allStores = new List<Brand>();  // contains all the brands in the shop
    static public List<ClothingProduct> allProducts = new List<ClothingProduct>(); // contains all the products in the shop
    static public List<ClothingProduct> cart = new List<ClothingProduct>(); // products that the user has selected
    static public List<Discount> discounts = new List<Discount>(); // contains all the discounts of the shop
    static public decimal total = 0; // starting value of total set to 0

    // static void Main(string[] args)
    // {
    //   displayHeader();

    //   createProducts();

    //   brand();

    //   displayOrderSummary();

    //   createDiscounts();

    //   applyDiscount();
    // }

    private static void displayHeader()
    {
      Console.Title = "Online Clothing Store"; // changing the console title
      string onlineStore = "Welcome to the Online Clothing Shopping Service\n";
      Console.SetCursorPosition((Console.WindowWidth - onlineStore.Length) / 2, Console.CursorTop);   // alligning the output to the center of the screen
      Console.BackgroundColor = ConsoleColor.DarkMagenta;
      Console.WriteLine(onlineStore);
      Console.ResetColor();

      string welcomeStatement = "Explore the interactive shopping Experience at our Store";
      Console.SetCursorPosition((Console.WindowWidth - welcomeStatement.Length) / 2, Console.CursorTop); // aligning to the center
      Console.WriteLine(welcomeStatement + "\n");
    }

    static void brand()
    {
      string displaySummary;
      do
      {
        Console.WriteLine("These are the Brands currently available in our store:\n");
        foreach (Brand store in allStores) // looping through all the brands and displaying their details
        {
          store.Print_values();
          Console.WriteLine();
        }
        Console.Write("Please enter the respective number of the Brand you would Like to purchase from: ");

        string selectedBrand = Console.ReadLine();

        List<ClothingProduct> itemsToList = getBrandItems(selectedBrand);

        foreach (ClothingProduct clothingProduct in itemsToList)
        {
          clothingProduct.getDetails();
        }
        Console.WriteLine();
        Console.WriteLine("Would you like to add this item to the cart? [Y/N]");

        string addToCart = Console.ReadLine().ToUpper();
        if ("Y".Equals(addToCart))
        {
          Console.WriteLine("Item successfully added to cart");
          foreach (ClothingProduct clothingProduct in itemsToList)
          {
            cart.Add(clothingProduct);  // adding the selected product to the cart
          }
        }
        else
        {
          Console.WriteLine("Item not added to cart");
        }


        Console.WriteLine("\nPlease enter 'Y' if you wish to add more items to the cart or enter 'N' if you wish to display the Order Summary");

        displaySummary = Console.ReadLine().ToUpper();
      }
      while ("Y".Equals(displaySummary)); // loops until the user wants to display the summary
    }

    private static void createProducts()
    {
      // hard coded brands
      Brand zara = new Brand("1", "Zara", "Germany");
      Brand tommy = new Brand("2", "Tommy", "Turkey");
      Brand gucci = new Brand("3", "Gucci", "United Kingdom");
      Brand armani = new Brand("4", "Armani", "Italy");

      allStores.Add(zara);
      allStores.Add(tommy);
      allStores.Add(gucci);
      allStores.Add(armani);


      // hard coded products with the brand
      Pant jeans = new Pant("Jeans", 15.5m, "M", "Blue", zara, "Denim", "Skinny");
      Pant chino = new Pant("Chinos", 17, "S", "Green", tommy, "Cotton", "Regular");
      Tshirt casual = new Tshirt("Casual T-shirt", 10, "XS", "Red", gucci, "V-neck", "Floral");
      Skirt modern = new Skirt("Modern Skirt", 12.25m, "L", "Purple", armani, "Midi", true);

      allProducts.Add(jeans);
      allProducts.Add(chino);
      allProducts.Add(casual);
      allProducts.Add(modern);
    }

    private static void displayOrderSummary()
    {
      Console.WriteLine("\nYour Order Summary is");

      // displaying the order summary details in a table format
      Console.WriteLine(String.Format("\n|{0,15}|{1,15}|", "Item Name", "Item Price"));

      foreach (ClothingProduct product in cart) // looping through the cart and displaying each item
      {
        Console.WriteLine(String.Format("|{0,15}|{1,15}|", product.name, String.Format("{0:.00}", product.price)));
        total += product.price; // calculating the total price
      }
      string border = "";
      for (var i = 0; i <= 30; i++)
      {
        border += "-";
      }
      Console.WriteLine("|{0}|", border);
      Console.WriteLine(String.Format("|{0,15}|{1,15}|", "Total Price", "$" + String.Format("{0:.00}", total)));
    }

    private static void createDiscounts()
    {
      // hard coded discount codes
      discounts.Add(new Discount("DISCOUNT25", 0.25m));
      discounts.Add(new Discount("SAVE15", 0.15m));
      discounts.Add(new Discount("FASHION20", 0.20m));
    }

    static void applyDiscount()
    {
      string userInput;
      Console.WriteLine("\nPlease enter a PromoCode to obtain your discount. If no PromoCode is available please type 'No' or simply hit ENTER.\n");

      Discount discount;

      bool skipPromo;

      // using a do while loop to give the customer the chance to try another promocode after an incorrect attempt
      do
      {
        Console.Write("PromoCode: ");
        userInput = Console.ReadLine().ToUpper().Trim(); // converting the user input to uppercase to avoid case sensitivity and trimming to avoid unnecessary spaces entered
        skipPromo = userInput == "NO" || userInput == ""; // used to skip promo applicataion if the user enters "NO" or an empty string
        discount = getDiscount(userInput);

        if (skipPromo) // skipping promocode application
        {
          Console.WriteLine("Proceeding without a PromoCode\n");
          Console.BackgroundColor = ConsoleColor.Red;
          Console.WriteLine("\nTotal Amount Payable =  ${0} ", String.Format("{0:.00}", total));
          Console.ResetColor();
        }
        else if (discount != null) // application of the promocode
        {
          decimal discountedAmount = total * discount.value; // calculating the discount amount

          Console.Write("PromoCode ");
          Console.BackgroundColor = ConsoleColor.Blue;
          Console.Write(userInput);
          Console.ResetColor();

          Console.WriteLine(" has been applied\n");

          Console.WriteLine("Discount Amount: " + String.Format("${0:.00}", discountedAmount));
          Console.BackgroundColor = ConsoleColor.Red;
          Console.WriteLine("\nTotal Amount Payable =  ${0} ", String.Format("{0:.00}", total - discountedAmount));
          Console.ResetColor();
        }
        else
        {
          Console.WriteLine("Invalid PromoCode, please try again or hit enter to proceed without a PromoCode\n");

        }
      } while (discount == null && !skipPromo);
    }

    private static Discount getDiscount(string userInput) // gets the entered discount or returns null if not found
    {
      Discount selectedDiscount = null;

      foreach (var discount in discounts) // finding the entered discount from the list
      {
        if (discount.code == userInput)
        {
          selectedDiscount = discount;
          break;
        }
      }
      return selectedDiscount;
    }

    static List<ClothingProduct> getBrandItems(string brandNumber)
    {
      Brand selectedBrand = null;
      foreach (var brand in allStores) // getting the entered brand
      {
        if (brand.number == brandNumber)
        {
          selectedBrand = brand;
        }
      }

      var brandItmes = new List<ClothingProduct>();

      foreach (ClothingProduct clothingProduct in allProducts) // filtering the products for the selected brand
      {
        if (clothingProduct.brand.Equals(selectedBrand))
        {
          brandItmes.Add(clothingProduct);
        }
      }
      return brandItmes;
    }
  }

  abstract class ClothingProduct // Base class to represent a product
  {
    public string name;
    public decimal price;
    public string size;
    public string colour;
    public Brand brand;

    public virtual void getDetails()
    {
      Console.WriteLine("Brand: " + brand.nameOfBrand);
      Console.WriteLine("Name: " + name);
      Console.WriteLine("Price: $" + price);
      Console.WriteLine("Size: " + size);
      Console.WriteLine("Colour: " + colour);
    }
  }

  class Brand
  {
    public string number;
    public string nameOfBrand;
    public string country;

    public Brand(string Number, string NameOfBrand, string Country)
    {
      this.number = Number;
      this.nameOfBrand = NameOfBrand;
      this.country = Country;
    }
    public Brand(string NameOfBrand)
    {
      this.nameOfBrand = NameOfBrand;
    }
    public void Print_values()
    {
      Console.WriteLine($"[{number}] - {nameOfBrand} from {country}");
      Console.WriteLine();
    }
  }

  class Pant : ClothingProduct // Derived class to represent a specific product type
  {
    public string material;
    public string fit;

    public Pant(string name, decimal price, string size, string colour, Brand brand, string material, string fit)
    {
      this.material = material;
      this.fit = fit;
      this.name = name;
      this.price = price;
      this.size = size;
      this.colour = colour;
      this.brand = brand;
    }

    public override void getDetails() // overriding the base class method
    {
      base.getDetails(); // calling the base class method
      Console.WriteLine("Material: " + material);
      Console.WriteLine("Fit: " + fit);
    }
  }

  class Tshirt : ClothingProduct
  {
    public string neck;
    public string print;

    public Tshirt(string name, decimal price, string size, string colour, Brand brand, string neck, string print)
    {
      this.neck = neck;
      this.print = print;
      this.name = name;
      this.price = price;
      this.size = size;
      this.colour = colour;
      this.brand = brand;
    }

    public override void getDetails()
    {
      base.getDetails();
      Console.WriteLine("Neck: " + neck);
      Console.WriteLine("Print: " + print);
    }
  }

  class Skirt : ClothingProduct
  {
    public string length;
    public bool belt;

    public Skirt(string name, decimal price, string size, string colour, Brand brand, string length, bool belt)
    {
      this.length = length;
      this.belt = belt;
      this.name = name;
      this.price = price;
      this.size = size;
      this.colour = colour;
      this.brand = brand;
    }

    public override void getDetails()
    {
      base.getDetails();
      Console.WriteLine("Length: " + length);
      string hasBelt = belt == true ? "Included" : "Not Included";
      Console.WriteLine("Belt: " + hasBelt);
    }
  }

  class Discount
  {
    public string code;
    public decimal value; // represents as a precentage

    public Discount(string code, decimal value)
    {
      this.code = code;
      this.value = value;
    }
  }

}
