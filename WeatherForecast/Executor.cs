
using WeatherForecast.Services;

namespace WeatherForecast
{
    public class Executor
    {

        private readonly ICityService _cityService;

        public Executor
            (
            ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task ExecuteAsync()
        {
            Console.WriteLine("Welcome to WeatherForecast\r");
            Console.WriteLine("------------------------\n");

            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please insert a command:\n");
                Console.ResetColor();
                var commandReceived = Console.ReadLine();
                if (commandReceived != null)
                {
                    var command = commandReceived.Trim().ToLower();
                    switch (command)
                    {
                        case "weather":
                            //TODO
                            break;
                        case "cities":
                            var output = await _cityService.GetListOfCitiesAsyncForOutput();
                            Printer.Print(output);
                            break;
                        case "help":
                            Printer.ShowHelp();
                            break;
                        default:
                            Console.WriteLine("Sorry, that command is not recognized");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, that command is not recognized");
                }
            }

        }
    }
}