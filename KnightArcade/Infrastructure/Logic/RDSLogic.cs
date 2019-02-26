using KnightArcade.Infrastructure.Data.Interface;
using KnightArcade.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Logic
{
    public class RDSLogic
    {
        private readonly IRDSData _rdsData;
        private readonly ILogger<RDSLogic> _logger;

        public RDSLogic(IRDSData rdsData, ILogger<RDSLogic> logger)
        {
            _rdsData = rdsData;
            _logger = logger;
        }

        ///////
        //// Games Table
        ///////

        public Games GetGames(int gameId)
        {
            try
            {
                return _rdsData.GetGames(gameId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public Games GetGames(string gameName)
        {
            try
            {
                return _rdsData.GetGames(gameName);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public List<Games> GetAllGames()
        {
            try
            {
                return _rdsData.GetAllGames();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public bool PostGames(Games game)
        {
            try
            {
                game.GameStatus = "t";
                game.GameOnarcade = false;
                game.GameSubmissiondateUtc = DateTime.UtcNow;
                _rdsData.PostGames(game);
                Games postedGame = _rdsData.GetGames(game.GameName);

                Submissions newSubmission = new Submissions()
                {
                    GameId = postedGame.GameId,
                    SubmissionDateUtc = postedGame.GameSubmissiondateUtc,
                    SubmissionImage0 = postedGame.GameImage0,
                    SubmissionName = postedGame.GameName,
                    SubmissionStatus = postedGame.GameStatus,
                    CreatorId = postedGame.GameCreatorId
                };

                _rdsData.PostSubmissions(newSubmission);

                TestsQueue newTestQueue = new TestsQueue()
                {
                    GameId = postedGame.GameId,
                    RetryCount = 0
                };

                _rdsData.PostTestsQueue(newTestQueue);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool PutGames(Games games)
        {
            try
            {
                _rdsData.PutGames(games);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool DeleteGames(int gameId)
        {
            try
            {
                _rdsData.DeleteGames(gameId);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        ///////
        //// Submissions Table
        ///////

        public Submissions GetSubmissions(int gameId)
        {
            try
            {
                return _rdsData.GetSubmissions(gameId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public List<Submissions> GetAllSubmissions()
        {
            try
            {
                return _rdsData.GetAllSubmissions();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public bool PostSubmissions(Submissions submission)
        {
            try
            {
                _rdsData.PostSubmissions(submission);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool PutSubissions(Submissions submission)
        {
            try
            {
                _rdsData.PutSubmissions(submission);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool DeleteSubmissions(int gameId)
        {
            try
            {
                _rdsData.DeleteSubmissions(gameId);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        ///////
        //// Tests Table
        ///////

        public Tests GetTests(int gameId)
        {
            try
            {
                return _rdsData.GetTests(gameId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public List<Tests> GetAllTests()
        {
            try
            {
                return _rdsData.GetAllTests();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public bool PostTests(Tests test)
        {
            try
            {
                _rdsData.PostTests(test);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool PutTests(Tests test)
        {
            try
            {
                _rdsData.PutTests(test);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool DeleteTests(int gameId)
        {
            try
            {
                _rdsData.DeleteTests(gameId);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        ///////
        //// TestsQueue Table
        ///////

        public TestsQueue GetTestsQueue(int gameId)
        {
            try
            {
                return _rdsData.GetTestsQueue(gameId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public TestsQueue GetTestsQueue()
        {
            try
            {
                return _rdsData.GetTestsQueue();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public List<TestsQueue> GetAllTestsQueue()
        {
            try
            {
                return _rdsData.GetAllTestsQueue();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public bool PostTestQueue(TestsQueue testsQueue)
        {
            try
            {
                _rdsData.PostTestsQueue(testsQueue);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool PutTestsQueue(TestsQueue testsQueue)
        {
            try
            {
                _rdsData.PutTestsQueue(testsQueue);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }

        public bool DeleteTestsQueue(int gameId)
        {
            try
            {
                _rdsData.DeleteTestsQueue(gameId);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }
    }
}
