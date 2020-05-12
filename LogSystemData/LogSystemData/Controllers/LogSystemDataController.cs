using System.Collections.Generic;
using LogSystemData.Generators;
using Microsoft.AspNetCore.Mvc;

namespace LogSystemData.Controllers
{
    [Route( "log-system-data" )]
    [ApiController]
    public class LogSystemDataController : ControllerBase
    {
        private readonly ILogSystemDataGenerator _logSystemDataGenerator;

        public LogSystemDataController( ILogSystemDataGenerator logSystemDataGenerator )
        {
            _logSystemDataGenerator = logSystemDataGenerator;
        }

        [HttpGet]
        [Route( "get-log-system-data" )]
        public ActionResult RefreshAllProvidersAsync()
        {
            return Ok( _logSystemDataGenerator.GenerateLogData() );
        }
    }
}
