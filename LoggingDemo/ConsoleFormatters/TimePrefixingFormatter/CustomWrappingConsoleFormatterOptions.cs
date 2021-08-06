using Microsoft.Extensions.Logging.Console;

namespace LoggingDemo.ConsoleFormatters.TimePrefixingFormatter
{
    public class CustomWrappingConsoleFormatterOptions : ConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }

        public string CustomSuffix { get; set; }
    }
}