
using WeatherForecast.Services;

namespace WeatherForecast
{
    public class Executor
    {

        private readonly ICityService _cityService;
        private readonly IWeatherService _weatherService;

        public Executor
            (IWeatherService weatherService, ICityService cityService)
        {
            _cityService = cityService;
            _weatherService = weatherService;
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
                            var weatherForecast = _weatherService.GetWeatherForecast();
                            Printer.Print(weatherForecast);
                            break;
                        case "cities":
                            var output = _cityService.GetListOfCitiesAsyncForOutput();
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