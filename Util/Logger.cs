using System;

namespace Util
{
  public static class Logger
  {
    public static void Info(string message)
    {
      Console.ForegroundColor = ConsoleColor.Blue;
      LogMessage(message);
    }

    public static void Warn(string message)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      LogMessage(message);
    }

    public static void Error(string message)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      LogMessage(message);
    }

    private static void LogMessage(string message)
    {
      Console.WriteLine(message);
      Console.ResetColor();
    }
  }
}
