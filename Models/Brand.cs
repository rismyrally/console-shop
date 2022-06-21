using System;

namespace Models
{
  public class Brand
  {
    public int BrandId;
    public string Name;
    public string Country;

    public Brand(int brandId, string name, string country)
    {
      this.BrandId = brandId;
      this.Name = name;
      this.Country = country;
    }
  }
}
