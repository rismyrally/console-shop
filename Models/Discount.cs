using System;

namespace Models
{
  public class Discount
  {
    public string Code;
    public decimal Value;

    public Discount(string code, decimal value)
    {
      this.Code = code;
      this.Value = value;
    }
  }
}
