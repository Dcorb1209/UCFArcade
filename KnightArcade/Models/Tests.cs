using System;
using System.Collections.Generic;

namespace KnightArcade.Models
{
    public partial class Tests
    {
        public int? GameId { get; set; }
        public sbyte? TestOpens { get; set; }
        public sbyte? Test5min { get; set; }
        public sbyte? TestCloses { get; set; }
        public sbyte? TestRandombuttons { get; set; }
        public int? TestAttempts { get; set; }
    }
}
