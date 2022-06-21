using System;
using Util;

namespace Models
{
  public class Product
  {
    public string ProductId;
    public string Name;
    public decimal Price;
    public ProductSize ProductSize;
    public Brand Brand;

    public Product(string productId, string name, decimal price, ProductSize productSize, Brand brand)
    {
      this.ProductId = productId;
      this.Name = name;
      this.Price = price;
      this.ProductSize = productSize;
      this.Brand = brand;
    }

    public void PrintDetails()
    {
      Console.WriteLine("{0,-3} {1,-20} {2,-20} {3,-7} {4,-7:C2}", ProductId, Brand.Name, Name, ProductSize, StringFormat.Amount(Price));
    }
  }

  public enum ProductSize
  {
    XS,
    S,
    M,
    L,
    XL
  }
}
