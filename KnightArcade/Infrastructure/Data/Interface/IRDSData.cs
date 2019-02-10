using KnightArcade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data.Interface
{
    public interface IRDSData
    {
        Games GetGames(int gameId);
        List<Games> GetAllGames();
        void PostGames(Games games);
        void PutGames(Games games);
        void DeleteGames(int gameId);
    }
}
