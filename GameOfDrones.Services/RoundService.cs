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


        public Player AddWithWinner(Round round)
        {
            Player winnerPlayer;

            if (_gameService.GetWinner(round.GameId) == null)
            {
                winnerPlayer = CheckRoundWinner(round);

                if (winnerPlayer != null)
                {
                    round.WinnerPlayerId = winnerPlayer.PlayerId;
                    _repository.Add(round);

                    var game = _gameService.UpdateResults(round.GameId);
                    winnerPlayer.Winner = game.WinnerPlayerId.HasValue
                            && winnerPlayer.PlayerId == game.WinnerPlayerId;
                }
            }
            else
            {
                throw new Exception("This game has already finished!");
            }
        
            return winnerPlayer;
        }


        private Player CheckRoundWinner(Round round)
        {
            var movesList = round.Moves.ToList();
            var winners = movesList.FindAll(p => movesList.Exists(m => _moveService.Kills(p.MoveId.Value, m.MoveId.Value)));

            if (winners != null && winners.Count == 1)
                return winners.FirstOrDefault().Player;
            else return null;
        }
    }
}
