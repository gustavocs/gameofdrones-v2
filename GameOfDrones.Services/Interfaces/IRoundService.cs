using GameOfDrones.Models;

namespace GameOfDrones.Services
{
    public interface IRoundService : IService<Round>
    {
        Round AddWithWinner(Round round);
    }
}