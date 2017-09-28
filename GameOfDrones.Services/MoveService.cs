using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;
using GameOfDrones.Data;

namespace GameOfDrones.Services
{
    public class MoveService : ServiceBase<Move>, IMoveService
    {
        private readonly IRepositoryBase<Move> _moveRepository;
        public MoveService(IRepositoryBase<Move> repository) : base(repository) { _moveRepository = repository; }

        public bool Kills(int moveId, int killsMoveId)
        {
            Move move = GetById(moveId);

            return (move.KillsMoveId == killsMoveId);
        }
    }
}
