using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedTesting.Infrastructure.Logic
{
    public class S3Logic
    {
        private readonly ILogger<S3Logic> _logger;

        public S3Logic (ILogger<S3Logic> logger)
        {
            _logger = logger;
        }
    }
}
