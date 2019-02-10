using AutomatedTesting.Infrastructure.Data.Infrastructure;
using AutomatedTesting.Models;
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
        private readonly IS3Data _s3Data;

        public TestingLogic(ILogger<TestingLogic> logger, IS3Data s3Data)
        {
            _logger = logger;
            _s3Data = s3Data;
        }

        public void Start()
        {
            //string debugFilePath = null;
            //string localFilePath = null;
            string debugKey = "arcade_games/AlienDefense5(Final).zip";
            string fileLocation = _s3Data.ReadObjectDataAsync(debugKey).Result;

            //get s3 and download zip file, return file location

            //unzip file and returned unzip location

            //start .exe, check to see if it started

            //Thread.Sleep(5000);

            //stop .exe, check to see if it stopped

            //Thread.Sleep(300);

        }
    }
}
