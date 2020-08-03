using System.Collections.Generic;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Data
{
    public class PathfinderRepository : IPathfinderRepository
    {
        private readonly DataContext _context;
        public PathfinderRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<Armor> GetArmor(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Armor>> GetArmors()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Armor>> GetArmors(int setNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<EnemyEntity>> GetEnemies()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<EnemyEntity>> GetEnemies(int setNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<EnemyEntity> GetEnemy(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<NonPlayerEntity> GetNonPlayer(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<NonPlayerEntity>> GetNonPlayers()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<NonPlayerEntity>> GetNonPlayers(int setNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<PlayerEntity> GetPlayer(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PlayerEntity>> GetPlayers()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PlayerEntity>> GetPlayers(int setNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<Potion> GetPotion(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Potion>> GetPotions()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Potion>> GetPotions(int setNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<Weapon> GetWeapon(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Weapon>> GetWeapons()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Weapon>> GetWeapons(int setNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
