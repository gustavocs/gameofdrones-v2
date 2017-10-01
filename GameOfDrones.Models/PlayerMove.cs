using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Models
{
    public class PlayerMove 
    {
        public int PlayerMoveId { get; set; }

        public int? MoveId { get; set; }
        public Move Move { get; set; }

        public int? PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
