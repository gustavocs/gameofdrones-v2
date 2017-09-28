using GameOfDrones.Models;

namespace GameOfDrones.Services
{
    public interface IConfigService : IService<Move>
    {
        GameConfig GetConfig();
        void UpdateConfig(GameConfig config);
    }
}