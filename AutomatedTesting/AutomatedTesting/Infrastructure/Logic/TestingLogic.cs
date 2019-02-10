using AutomatedTesting.Infrastructure.Data.Infrastructure;
using AutomatedTesting.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
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
            string unzipFile = Unzip(zipFile);

            //Find .exe file path
            string exeFile = findExe(unzipFile);

            //start .exe, check to see if it started
            bool startTest = startFile(exeFile);

            //Thread.Sleep(5000);
            bool sleepTest = sleepFile(exeFile);

            //stop .exe, check to see if it stopped
            bool stopTest = stopFile(exeFile);

        }

        public string Unzip(string zipFile)
        {
            string extractPath = @".\extract";

            ZipFile.ExtractToDirectory(zipFile, extractPath);

            return extractPath;
        }

        string findExe(string unzipFile)
        {
            string[] files = System.IO.Directory.GetFiles(unzipFile, "*.exe");

            return files[0];
        }

        public bool startFile(string exeFile)
        {
            Process.Start(exeFile);

            return Process.GetProcessesByName(exeFile)
                .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"c:\loc1")) != default(Process);
        }

        public bool sleepFile(string exeFile)
        {
            Thread.Sleep(5000);

            return Process.GetProcessesByName(exeFile)
               .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"c:\loc1")) != default(Process);
        }

        public bool stopFile(string exeFile)
        {
            

            Thread.Sleep(300);

            return Process.GetProcessesByName(exeFile)
               .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"c:\loc1")) != default(Process);
        }
    }
}
