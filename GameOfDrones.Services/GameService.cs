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
            Game game = _gameRepository.GetById(gameId);
            CheckWinner(game);

            return game;
        }

        public void CheckWinner(Game game)
        {
            foreach (Player p in game.Players)
            {
                if (game.Rounds.Count(r => r.WinnerPlayerId == p.PlayerId) >= GameConfig.WIN_LIMIT)
                    p.Winner = true;
            }
        }
    }
}
