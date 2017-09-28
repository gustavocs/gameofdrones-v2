using GameOfDrones.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Data
{
    public class GameRepository : RepositoryBase<Game>
    {
        public GameRepository(IDbContext context) : base(context)
        {

        }

    }
}
