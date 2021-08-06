using Microsoft.Extensions.Logging.Console;

namespace LoggingDemo.ConsoleFormatters.ColorFormatter
{
    public class CustomColorOptions : SimpleConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }
    }
}