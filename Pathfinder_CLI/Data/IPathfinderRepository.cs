using System.Collections.Generic;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Data
{
    public interface IPathfinderRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<CharacterData> GetPlayer(int id);
        Task<CharacterData> GetEnemy(int id);
        Task<CharacterData> GetNonPlayer(int id);
        Task<WeaponData> GetWeapon(int id);
        Task<ArmorData> GetArmor(int id);
        Task<PotionData> GetPotion(int id);
        Task<IEnumerable<CharacterData>> GetPlayers();
        Task<IEnumerable<CharacterData>> GetEnemies();
        Task<IEnumerable<CharacterData>> GetNonPlayers();
        Task<IEnumerable<WeaponData>> GetWeapons();
        Task<IEnumerable<ArmorData>> GetArmors();
        Task<IEnumerable<PotionData>> GetPotions();
        Task<IEnumerable<CharacterData>> GetPlayers(int setNumber);
        Task<IEnumerable<CharacterData>> GetEnemies(int setNumber);
        Task<IEnumerable<CharacterData>> GetNonPlayers(int setNumber);
        Task<IEnumerable<WeaponData>> GetWeapons(int setNumber);
        Task<IEnumerable<ArmorData>> GetArmors(int setNumber);
        Task<IEnumerable<PotionData>> GetPotions(int setNumber);
        
    }
}