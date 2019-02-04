using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data.Interface
{
    public interface IAutomatedTestingData
    {
        bool PostGameForTesting(string url, object game, object config);
    }
}
