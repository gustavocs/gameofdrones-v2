using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Models
{
    public class Round 
    {
        public int RoundId { get; set; }

        public int? WinnerPlayerId { get; set; }
        public Player Winner { get; set; }

        [JsonIgnore]
        public Game Game { get; set; }
        public int GameId { get; set; }

        public ICollection<PlayerMove> Moves { get; set; }

    }
}
