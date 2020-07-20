using System;
using System.Collections.Generic;
using System.Linq;
using adventure_cli._data;
using adventure_cli._models.characterData;
using adventure_cli._models.entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace adventure_cli.Helpers
{
    public class Seed
    {

        public static void SeedData(DataContext context)
        {
            context.Database.Migrate();
            if(!context.Character_Tbl.Any())
            {
                var armors = GetArmorData();
                var weapons = GetWeaponData();
                var potions = GetPotionData();
                var enemies = GetEnemyData();
                var players = GetPlayerData();

                foreach(var weapon in weapons)
                {
                    context.Weapon_Tbl.Add(weapon);
                }

                foreach(var armor in armors)
                {
                    context.Armor_Tbl.Add(armor);
                }

                foreach(var potion in potions)
                {
                    context.Potion_Tbl.Add(potion);
                }

                foreach(var enemy in enemies)
                {
                    context.Character_Tbl.Add(enemy);
                }

                foreach(var player in players)
                {
                    context.Character_Tbl.Add(player);
                }

                context.SaveChanges();
            }
        }
        public static List<ArmorData> GetArmorData()
        {
            var armorData = System.IO.File.ReadAllText("Helpers/Seeds/SeedArmorData.json");
            var items = JsonConvert.DeserializeObject<List<ArmorData>>(armorData);

            return items;
        }

        public static List<CharacterData> GetPlayerData()
        {
            var playerData = System.IO.File.ReadAllText("Helpers/Seeds/SeedPlayerData.json");
            var players = JsonConvert.DeserializeObject<List<CharacterData>>(playerData);

            return players;
        }

        public static List<CharacterData> GetEnemyData()
        {
            var characterData = System.IO.File.ReadAllText("Helpers/Seeds/SeedEnemyData.json");
            var characters = JsonConvert.DeserializeObject<List<CharacterData>>(characterData);
            
            return characters;
        }

        public static List<WeaponData> GetWeaponData()
        {
            var weaponData = System.IO.File.ReadAllText("Helpers/Seeds/SeedWeaponData.json");
            var weapons = JsonConvert.DeserializeObject<List<WeaponData>>(weaponData);

            return weapons;
        }

        public static List<PotionData> GetPotionData()
        {
            var potionData = System.IO.File.ReadAllText("Helpers/Seeds/SeedPotionData.json");
            var potions = JsonConvert.DeserializeObject<List<PotionData>>(potionData);

            return potions;
        }
    }
}