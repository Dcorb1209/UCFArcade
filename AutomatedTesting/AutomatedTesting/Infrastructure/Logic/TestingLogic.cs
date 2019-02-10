using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedTesting.Infrastructure.Logic
{
    public class TestingLogic
    {
        private readonly ILogger<TestingLogic> _logger;

        public TestingLogic(ILogger<TestingLogic> logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            //get s3 and download zip file, return file location

            //unzip file and returned unzip location

            //start .exe, check to see if it started

            //Thread.Sleep(5000);

            //stop .exe, check to see if it stopped

            //Thread.Sleep(300);

        }
    }
}
