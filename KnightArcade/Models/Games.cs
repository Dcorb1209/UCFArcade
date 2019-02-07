using System;
using System.Collections.Generic;

namespace KnightArcade.Models
{
    public partial class Games
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int GameCreator { get; set; }
        public string GameCreatorName { get; set; }
        public string GameDescription { get; set; }
        public string GameControls { get; set; }
        public string GameBanner { get; set; }
        public string GameGenres { get; set; }
    }
}
