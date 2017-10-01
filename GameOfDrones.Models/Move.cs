using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Models
{
    public class Move 
    {
        public int MoveId { get; set; }
        public string Name { get; set; }

        public int? KillsMoveId { get; set; }
        public Move Kills { get; set; }
    }
}
