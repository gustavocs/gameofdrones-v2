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
        private IGameService _gameService;
        private IMoveService _moveService;

        public RoundService(IRepositoryBase<Round> repository, 
            IMoveService moveService,
            IGameService gameService) 
                : base(repository)
        {
            _gameService = gameService;
            _moveService = moveService;
        }


        public Round AddWithWinner(Round round)
        {
            Round roundResult;
            if (_gameService.GetWinner(round.GameId) == null)
            {

                round.WinnerPlayerId = CheckRoundWinner(round);
                roundResult = _repository.Add(round);

                _gameService.UpdateResults(round.GameId);
            }
            else
            {
                throw new Exception("This game has already finished!");
            }
        
            return roundResult;
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
