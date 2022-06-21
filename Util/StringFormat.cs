using System;
using System.Globalization;

namespace Util
{
  public static class StringFormat
  {
    private static CultureInfo _culture = new CultureInfo("de-DE");

    public static string Amount(decimal amount)
    {
      return string.Format(_culture, "{0:C2}", amount);
    }
  }
}
