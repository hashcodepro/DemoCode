using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using LoggingDemo.ConsoleFormatters;
using LoggingDemo.ConsoleFormatters.TimePrefixingFormatter;
using LoggingDemo.ConsoleFormatters.ColorFormatter;

namespace LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using (EventLog eventLog = new EventLog("LoggingExample"))
            // {
            //     if (!EventLog.SourceExists("DemoSource"))
            //     {
            //         EventLog.CreateEventSource("DemoSource", "LoggingExample");
            //     }
            // }
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("The Application has started at {Time}", DateTime.UtcNow);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    // logging.AddConsole();

                    // logging
                    // .AddConsole()
                    // .AddConsoleFormatter<CustomTimePrefixingFormatter, CustomWrappingConsoleFormatterOptions>();

                    // logging
                    //     .AddSimpleConsole();

                    // logging.AddSimpleConsole(options =>
                    // {
                    //     options.IncludeScopes = false;
                    //     options.SingleLine = true;
                    //     options.TimestampFormat = "dd-MM-yyyy:hh.mm.ss|";
                    //     options.UseUtcTimestamp = true;
                    //     // options.ColorBehavior = LoggerColorBehavior.Enabled;
                    // });

                    // logging.AddSystemdConsole();

                    // logging.AddSystemdConsole(options =>
                    // {
                    //     options.IncludeScopes = false;
                    //     options.UseUtcTimestamp = true;
                    //     options.TimestampFormat = "dd-MMMM-yyyy:hh.mm.ss|";
                    // });

                    // logging.AddJsonConsole(options =>
                    // {
                    //     options.IncludeScopes = false;
                    //     options.TimestampFormat = "dd-MMMM-yyyy:hh.mm.ss";
                    //     options.UseUtcTimestamp = true;
                    //     options.JsonWriterOptions = new JsonWriterOptions
                    //     {
                    //         Indented = true
                    //     };
                    // });

                    // logging.AddEventLog(eventLogSettings =>
                    // {
                    //     eventLogSettings.SourceName = "DemoSource";
                    //     eventLogSettings.LogName = "LoggingExample";
                    // });
                    //Event Source, Event Log, Trace Source, Azure App Services File/BLOB,ApplicationInsights
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
