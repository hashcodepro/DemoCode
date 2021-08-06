using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LoggingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        // private readonly ILogger _logger;

        // public IndexModel(ILoggerFactory factory)
        // {
        //     _logger = factory.CreateLogger("LoggingDemo.Category");
        // }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Logging Levels
            _logger.LogTrace("This is a trace log.");
            _logger.LogDebug("This is a debug log.");
            _logger.LogInformation("This is an information log.");
            _logger.LogWarning("This is a warning log.");
            _logger.LogError("This is a error log.");
            _logger.LogCritical("This is a critical log.");

            _logger.LogError("The server went temporarily down at {Time}", DateTime.UtcNow);

            try
            {

                throw new Exception("Random Exception");
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical(ex, "There was an exception at {Time}", DateTime.UtcNow);
            }
        }
    }
}
