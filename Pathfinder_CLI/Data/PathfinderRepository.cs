using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Models;
using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Data
{
    public class PathfinderRepository : IPathfinderRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
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

        public async Task<ArmorData> GetArmor(int id)
        {
            var armorData = await _context.Armor_Tbl.FirstOrDefaultAsync(x => x.Id == id);
            return armorData;
        }

        public async Task<IEnumerable<ArmorData>> GetArmors()
        {
            var armorData = await _context.Armor_Tbl.ToListAsync();
            return armorData;
        }

        public async Task<IEnumerable<ArmorData>> GetArmors(int setNumber)
        {
            var table = _context.Armor_Tbl;
            List<ArmorData> armorData = await GetRandomSetOfItems<ArmorData>(table, setNumber);

            return armorData;
        }

        public async Task<IEnumerable<CharacterData>> GetEnemies()
        {
            var enemyData = await _context.Character_Tbl.Where(data => data.Type == "Enemy").Include(x => x.Inventory).Include(x => x.Equipment).ToListAsync();
            return enemyData;
        }

        public async Task<IEnumerable<CharacterData>> GetEnemies(int setNumber)
        {
            var enemyData = await GetRandomSetOfCharacters(setNumber, "Enemy");
            return enemyData;
        }

        public async Task<CharacterData> GetEnemy(int id)
        {
            var enemyData = await _context.Character_Tbl.Include(x => x.Inventory).Include(x => x.Equipment).FirstOrDefaultAsync(x => x.Id == id);
            return enemyData;
        }

        public async Task<CharacterData> GetNonPlayer(int id)
        {
            var npcData = await _context.Character_Tbl.Include(x => x.Inventory).Include(x => x.Equipment).FirstOrDefaultAsync(x => x.Id == id);
            return npcData;
        }

        public async Task<IEnumerable<CharacterData>> GetNonPlayers()
        {
            var npcData = await _context.Character_Tbl.Where(x => x.Type == "NPC").Include(x => x.Inventory).Include(x => x.Equipment).ToListAsync();
            return npcData;
        }

        public async Task<IEnumerable<CharacterData>> GetNonPlayers(int setNumber)
        {
            var npcData = await GetRandomSetOfCharacters(setNumber, "NPC");
            return npcData;
        }

        public async Task<CharacterData> GetPlayer(int id)
        {
            var playerData = await _context.Character_Tbl.Include(x => x.Inventory).Include(x => x.Equipment).FirstOrDefaultAsync(x => x.Id == id);
            return playerData;
        }

        public async Task<IEnumerable<CharacterData>> GetPlayers()
        {
            var playerData = await _context.Character_Tbl.Where(x => x.Type == "Player").Include(x => x.Inventory).Include(x => x.Equipment).ToListAsync();
            return playerData;
        }

        public async Task<IEnumerable<CharacterData>> GetPlayers(int setNumber)
        {
            var playerData = await GetRandomSetOfCharacters(setNumber, "Player");
            return playerData;
        }

        public async Task<PotionData> GetPotion(int id)
        {
            var potionData = await _context.Potion_Tbl.FirstOrDefaultAsync(x => x.Id == id);
            return potionData;
        }

        public async Task<IEnumerable<PotionData>> GetPotions()
        {
            var potionData = await _context.Potion_Tbl.ToListAsync();
            return potionData;
        }

        public async Task<IEnumerable<PotionData>> GetPotions(int setNumber)
        {
            var table = _context.Potion_Tbl;
            var potionData = await GetRandomSetOfItems<PotionData>(table, setNumber);
            return potionData;
        }

        public async Task<WeaponData> GetWeapon(int id)
        {
            var weaponData = await _context.Weapon_Tbl.FirstOrDefaultAsync(x => x.Id == id);
            return weaponData;
        }

        public async Task<IEnumerable<WeaponData>> GetWeapons()
        {
            var weaponData = await _context.Weapon_Tbl.ToListAsync();
            return weaponData;
        }

        public async Task<IEnumerable<WeaponData>> GetWeapons(int setNumber)
        {
            var table = _context.Weapon_Tbl;
            var weaponData = await GetRandomSetOfItems<WeaponData>(table, setNumber);
            return weaponData;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<List<TData>> GetRandomSetOfItems<TData>(DbSet<TData> table, int setNumber) where TData : class, IData
        {
            var count = await table.CountAsync();
            List<TData> itemDataToReturn = new List<TData>();
    
            Random rand = new Random();
            for(int i = 0; i < setNumber; i++)
            {
                var randomId = rand.Next(1, count);
                var itemData = await table.FirstOrDefaultAsync(x => x.GetId() == randomId);
                itemDataToReturn.Add(itemData);
            }

            return itemDataToReturn;
        }

        private async Task<List<CharacterData>> GetRandomSetOfCharacters(int setNumber, string Type)
        {
            var validIds = await _context.Character_Tbl.Where(x => x.Type == Type).Select(x => x.Id).ToListAsync();
            List<CharacterData> characterDataToReturn = new List<CharacterData>();
            //Get a random id, and get the character associated with that id
            Random rand = new Random();
            for(int i = 0; i < setNumber; i++)
            {
                var randomId = validIds[rand.Next(1, validIds.Count())];
                var characterData = await _context.Character_Tbl.FirstOrDefaultAsync(x => x.Id == randomId);
                characterDataToReturn.Add(characterData);
            }

            return characterDataToReturn;
        }
    }
}
