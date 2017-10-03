using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;
using GameOfDrones.Data;

namespace GameOfDrones.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        private readonly IRepositoryBase<Game> _gameRepository;
        public GameService(IRepositoryBase<Game> repository) : base(repository) { _gameRepository = repository; }

        public Game GetResults(int gameId)
        {
            var game = _gameRepository.FindBy(
                            g => g.GameId == gameId,
                            g => g.Players,
                            g => g.Rounds)
                                .FirstOrDefault();

            return game;
        }

        public Player GetWinner(int gameId)
        {
            var winnerPlayer = _gameRepository.FindBy(
                                    g => g.GameId == gameId,
                                    g => g.WinnerPlayer)
                                            .FirstOrDefault();

            return winnerPlayer?.WinnerPlayer;
        }

        public Game UpdateResults(int gameId)
        {
            var game = _gameRepository.FindBy(
                            g => g.GameId == gameId,
                            g => g.Rounds,
                            g => g.Players)
                                .FirstOrDefault();

            if (game != null)
            {
                game.WinnerPlayerId = CheckWinner(game);
                if (game.WinnerPlayerId.HasValue)
                {
                    Update(game);
                }
            }

            return game;
        }

        private int? CheckWinner(Game game)
        {
            foreach (Player p in game.Players)
            {
                if (game.Rounds != null && game.Rounds.Count(r => r.WinnerPlayerId == p.PlayerId) >= GameConfig.WIN_LIMIT)
                {
                    p.Winner = true;
                    return p.PlayerId;
                }
            }
            return null;
        }
    }
}
