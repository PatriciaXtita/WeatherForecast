using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    internal class Printer
    {
        internal static void ShowHelp()
        {
            Console.WriteLine("\nHere's the list of commands you can use:\n");

            //Command List Cities
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("cities");
            Console.ResetColor();
            Console.WriteLine(" - List available cities with experiences\n");

            //Command List Weather
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("weather");
            Console.ResetColor();
            Console.WriteLine(" - List cities weather for the next 2 days\n");

            //Command Exit
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Exit");
            Console.ResetColor();
            Console.WriteLine(" - Close the program by passing the Exit command\n");
            Console.WriteLine("------------------------");
        }


        internal static void Print(StringBuilder s)
        {
            Console.WriteLine(s.ToString());
        }
    }
}
