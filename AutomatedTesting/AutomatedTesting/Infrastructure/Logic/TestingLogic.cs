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
        private readonly object _sync;
        public TestingVariables testProcess = new TestingVariables();


        public TestingLogic(ILogger<TestingLogic> logger, IS3Data s3Data)
        {
            _logger = logger;
            _s3Data = s3Data;
        }

        public void Start()
        {
            try
            {
                lock(_sync)
                {
                    //string debugFilePath = null;
                    //string localFilePath = null;
                    string debugKey = "arcade_games/AlienDefense5(Final).zip";
                    string fileLocation = _s3Data.ReadObjectDataAsync(debugKey).Result;

                    //get s3 and download zip file, return file location

                    //unzip file and returned unzip location
                    string unzipFile = Unzip(fileLocation);

                    //Find .exe file path
                    string exeFile = FindExe(unzipFile);

                    //start .exe, check to see if it started
                    bool startTest = StartFile(exeFile);

                    //Thread.Sleep(5000);
                    bool sleepTest = SleepFile(exeFile);

                    //stop .exe, check to see if it stopped
                    bool stopTest = StopFile(exeFile);
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
            }
            

        }

        public string Unzip(string zipFile)
        {
            try
            {
                string extractPath = @".\extract";

                ZipFile.ExtractToDirectory(zipFile, extractPath);

                return extractPath;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        string FindExe(string unzipFile)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(unzipFile, "*.exe");

                return files[0];
            }

            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
            
        }

        public bool StartFile(string exeFile)
        {
            try
            {
               testProcess.GameProcess = Process.Start(exeFile);

                return Process.GetProcessesByName(exeFile)
                    .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"c:\loc1")) != default(Process);
            }

            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }         
        }

        public bool SleepFile(string exeFile)
        {
            try
            {
                Thread.Sleep(5000);

                return Process.GetProcessesByName(exeFile)
                   .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"c:\loc1")) != default(Process);
            }

            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool StopFile(string exeFile)
        {
            try
            {
                testProcess.GameProcess.Close();
                Thread.Sleep(300);

                return Process.GetProcessesByName(exeFile)
                   .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"c:\loc1")) != default(Process);
            }

            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }
    }
}
