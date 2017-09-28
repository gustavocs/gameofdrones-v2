using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;
using GameOfDrones.Data;

namespace GameOfDrones.Services
{
    public class RoundService : ServiceBase<Round>, IRoundService
    {
        private IMoveService _moveService;
        public RoundService(IRepositoryBase<Round> repository, IMoveService moveService) : base(repository) { _moveService = moveService; }


        public Round AddWithWinner(Round round)
        {
            round.WinnerPlayerId = CheckRoundWinner(round);
            return _repository.Add(round);
        }

        private int? CheckRoundWinner(Round round)
        {
            var movesList = round.Moves.ToList();
            var winners = movesList.FindAll(p => movesList.Exists(m => _moveService.Kills(p.MoveId.Value, m.MoveId.Value)));

            if (winners != null && winners.Count == 1)
                return winners.FirstOrDefault().PlayerId;
            else return null;
        }
    }
}
