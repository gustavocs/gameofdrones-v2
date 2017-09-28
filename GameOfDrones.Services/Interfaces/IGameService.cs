using GameOfDrones.Models;

namespace GameOfDrones.Services
{
    public interface IGameService : IService<Game>
    {
        Game GetResults(int gameId);
        void CheckWinner(Game game);
    }
}
