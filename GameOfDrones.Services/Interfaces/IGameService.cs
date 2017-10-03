using GameOfDrones.Models;

namespace GameOfDrones.Services
{
    public interface IGameService : IService<Game>
    {
        Game GetResults(int gameId);
        Game UpdateResults(int gameId);
        Player GetWinner(int gameId);
    }
}
