using System;

namespace Models
{
  public class Cart
  {
    public List<Product> Products = new List<Product>();
    public decimal TotalCost = 0;
    public decimal DiscountAmount = 0;

    public void AddProduct(Product product)
    {
      Products.Add(product);
      TotalCost += product.Price;
    }

    public void ApplyDiscount(Discount discount)
    {
      DiscountAmount = TotalCost * discount.Value;
      TotalCost -= DiscountAmount;
    }

    public bool IsEmpty()
    {
      return Products.Count == 0;
    }
  }
}
