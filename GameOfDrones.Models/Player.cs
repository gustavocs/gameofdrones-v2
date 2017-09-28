using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Models
{
    public class Player : IModel
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public byte Number { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public bool Winner { get; set; }

    }
}
