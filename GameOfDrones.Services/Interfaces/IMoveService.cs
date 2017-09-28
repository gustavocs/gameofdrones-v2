using GameOfDrones.Models;

namespace GameOfDrones.Services
{
    public interface IMoveService : IService<Move>
    {
        bool Kills(int move, int kills);
    }
}