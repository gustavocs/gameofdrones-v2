using GameOfDrones.Models;

namespace GameOfDrones.Services
{
    public interface IRoundService : IService<Round>
    {
        Player AddWithWinner(Round round);
    }
}