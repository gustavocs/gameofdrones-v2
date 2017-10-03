using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Models
{
    public class Game 
    {
        public int GameId { get; set; }

        [JsonIgnore]
        public Player WinnerPlayer { get; set; }
        public int? WinnerPlayerId { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}
