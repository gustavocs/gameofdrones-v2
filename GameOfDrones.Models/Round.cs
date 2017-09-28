using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Models
{
    public class Round : IModel
    {
        public int Id { get; set; }

        public int RoundId { get; set; }

        public int? WinnerPlayerId { get; set; }
        public Player Winner { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public ICollection<PlayerMove> Moves { get; set; }

    }
}
