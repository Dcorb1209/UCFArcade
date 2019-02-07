using KnightArcade.Infrastructure.Data.Interface;
using KnightArcade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data
{
    public class RDSData : IRDSData
    {
        private readonly IConfiguration _configuration;

        public RDSData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Games GetGames(int gameId)
        {
            DbContextOptionsBuilder<KnightsArcadeContext> bootUp = new DbContextOptionsBuilder<KnightsArcadeContext>();            bootUp.UseMySql(_configuration.GetConnectionString("KnightsArcadeDb"));            KnightsArcadeContext knightsContext = new KnightsArcadeContext(bootUp.Options);

            Games myGame = knightsContext.Games.Find(gameId);
            return myGame;
        }

        public void PostGames(Games games)
        {
            DbContextOptionsBuilder<KnightsArcadeContext> bootUp = new DbContextOptionsBuilder<KnightsArcadeContext>();            bootUp.UseMySql(_configuration.GetConnectionString("KnightsArcadeDb"));            KnightsArcadeContext knightsContext = new KnightsArcadeContext(bootUp.Options);

            knightsContext.Games.Add(games);
            knightsContext.SaveChanges();
        }

        public void PutGames(Games games)
        {
            DbContextOptionsBuilder<KnightsArcadeContext> bootUp = new DbContextOptionsBuilder<KnightsArcadeContext>();            bootUp.UseMySql(_configuration.GetConnectionString("KnightsArcadeDb"));            KnightsArcadeContext knightsContext = new KnightsArcadeContext(bootUp.Options);

            Games myGame = knightsContext.Games.Find(games.GameId);
            knightsContext.Games.Remove(myGame);

            if (games.GameBanner != null) { myGame.GameBanner = games.GameBanner; }
            if (games.GameControls != null) { myGame.GameControls = games.GameControls; }
            if (games.GameCreatorName != null) { myGame.GameCreatorName = games.GameCreatorName; }
            if (games.GameDescription != null) { myGame.GameDescription = games.GameDescription; }
            if (games.GameGenres != null) { myGame.GameGenres = games.GameGenres; }
            if (games.GameName != null) { myGame.GameName = games.GameName; }

            knightsContext.Games.Add(myGame);
            knightsContext.SaveChanges();
        }

        public void DeleteGames(int gameId)
        {
            DbContextOptionsBuilder<KnightsArcadeContext> bootUp = new DbContextOptionsBuilder<KnightsArcadeContext>();            bootUp.UseMySql(_configuration.GetConnectionString("KnightsArcadeDb"));            KnightsArcadeContext knightsContext = new KnightsArcadeContext(bootUp.Options);

            Games myGame = knightsContext.Games.Find(gameId);
            knightsContext.Games.Remove(myGame);
            knightsContext.SaveChanges();
        }
    }
}
