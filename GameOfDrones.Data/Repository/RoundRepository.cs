using GameOfDrones.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Data
{
    public class RoundRepository : RepositoryBase<Round>
    {
        public RoundRepository(IDbContext context) : base(context)
        {

        }

    }
}
