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

        public bool PostGames(Games games)
        {
            try
            {
                _rdsData.PostGames(games);
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
    }
}
