using System.Collections.Generic;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Data
{
    public interface IPathfinderRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PlayerEntity> GetPlayer(int id);
        Task<EnemyEntity> GetEnemy(int id);
        Task<NonPlayerEntity> GetNonPlayer(int id);
        Task<Weapon> GetWeapon(int id);
        Task<Armor> GetArmor(int id);
        Task<Potion> GetPotion(int id);
        Task<IEnumerable<PlayerEntity>> GetPlayers();
        Task<IEnumerable<EnemyEntity>> GetEnemies();
        Task<IEnumerable<NonPlayerEntity>> GetNonPlayers();
        Task<IEnumerable<Weapon>> GetWeapons();
        Task<IEnumerable<Armor>> GetArmors();
        Task<IEnumerable<Potion>> GetPotions();
        Task<IEnumerable<PlayerEntity>> GetPlayers(int setNumber);
        Task<IEnumerable<EnemyEntity>> GetEnemies(int setNumber);
        Task<IEnumerable<NonPlayerEntity>> GetNonPlayers(int setNumber);
        Task<IEnumerable<Weapon>> GetWeapons(int setNumber);
        Task<IEnumerable<Armor>> GetArmors(int setNumber);
        Task<IEnumerable<Potion>> GetPotions(int setNumber);
    }
}