using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;
using GameOfDrones.Data;

namespace GameOfDrones.Services
{
    public class ConfigService : ServiceBase<Move>, IConfigService
    {
        public ConfigService(IRepositoryBase<Move> repository) : base(repository) { }

        public GameConfig GetConfig()
        {
            GameConfig config = new GameConfig();
            config.Moves = GetAll().ToArray();

            return config;
        }

        public void UpdateConfig(GameConfig config)
        {
            var movesToUpdate = GetAll();
            foreach (Move move in movesToUpdate)
            {
                var updateMove = config.Moves.FirstOrDefault(m => m.MoveId == move.MoveId);
                if(updateMove != null)
                {
                    move.Name = updateMove.Name;
                    move.KillsMoveId = updateMove.KillsMoveId;
                    Update(move);
                }
                else
                {
                    Remove(move);
                }
            }
            foreach (Move move in config.Moves)
            {
                var updateMove = movesToUpdate.FirstOrDefault(m => m.MoveId == move.MoveId);
                if (updateMove == null)
                {
                    Add(move);
                }
            }
        }
    }
}
