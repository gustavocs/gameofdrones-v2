using GameOfDrones.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Data
{
    public class PlayerRepository : RepositoryBase<Player>
    {
        public PlayerRepository(IDbContext context) : base(context)
        {

        }

    }
}
