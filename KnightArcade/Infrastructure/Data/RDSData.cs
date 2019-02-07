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

            if (games.GameControls != null) { myGame.GameControls = games.GameControls; }
            if (games.GameCreatorname != null) { myGame.GameCreatorname = games.GameCreatorname; }
            if (games.GameDescription != null) { myGame.GameDescription = games.GameDescription; }
            if (games.GameGenres != null) { myGame.GameGenres = games.GameGenres; }
            if (games.GameImage0 != null) { myGame.GameImage0 = games.GameImage0; }
            if (games.GameImage1 != null) { myGame.GameImage1 = games.GameImage1; }
            if (games.GameImage2 != null) { myGame.GameImage2 = games.GameImage2; }
            if (games.GameImage3 != null) { myGame.GameImage3 = games.GameImage3; }
            if (games.GameImage4 != null) { myGame.GameImage4 = games.GameImage4; }
            if (games.GameName != null) { myGame.GameName = games.GameName; }
            if (games.GamePath != null) { myGame.GamePath = games.GamePath; }
            if (games.GameReviewdate != null) { myGame.GameReviewdate = games.GameReviewdate; }
            if (games.GameStatus != null) { myGame.GameStatus = games.GameStatus; }
            if (games.GameVideolink != null) { myGame.GameVideolink = games.GameVideolink; }
            myGame.GameOnarcade = games.GameOnarcade;

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
