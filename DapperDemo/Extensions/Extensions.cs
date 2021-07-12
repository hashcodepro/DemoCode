using System;
using System.Text.Json;

namespace DapperDemo
{
    public static class Extensions
    {
        public static void FormatOutput(this object item)
        {
            Console.WriteLine(
                JsonSerializer.Serialize(
                    item, new JsonSerializerOptions { WriteIndented = true }
                ));
        }
    }
}