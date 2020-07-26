using System.Collections.Generic;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Data
{
    public interface IPathfinderRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<Armor> GetArmor(int id);
        Task<IEnumerable<Armor>> GetArmors();
    }
}