using System.Collections.Generic;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Data
{
    public class PathfinderRepository : IPathfinderRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Armor> GetArmor(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Armor>> GetArmors()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}