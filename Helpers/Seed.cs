using System;
using System.Collections.Generic;
using System.Linq;
using adventure_cli._data;
using adventure_cli._models.characterData;
using Newtonsoft.Json;

namespace adventure_cli.Helpers
{
    public class Seed
    {
        public static ArmorData[] SeedArmorData()
        {
            var armorData = System.IO.File.ReadAllText("Helpers/Seeds/SeedArmorData.json");
            var items = JsonConvert.DeserializeObject<List<ArmorData>>(armorData);

            return items.ToArray();
        }

        public static CharacterData[] SeedPlayerData()
        {
            var playerData = System.IO.File.ReadAllText("Helpers/Seeds/SeedPlayerData.json");
            var players = JsonConvert.DeserializeObject<List<CharacterData>>(playerData);

            return players.ToArray();
        }

        public static CharacterData[] SeedEnemyData()
        {
            var characterData = System.IO.File.ReadAllText("Helpers/Seeds/SeedEnemyData.json");
            var characters = JsonConvert.DeserializeObject<List<CharacterData>>(characterData);
            
            return characters.ToArray();
        }

        public static WeaponData[] SeedWeaponData()
        {
            var weaponData = System.IO.File.ReadAllText("Helpers/Seeds/SeedWeaponData.json");
            var weapons = JsonConvert.DeserializeObject<List<WeaponData>>(weaponData);

            return weapons.ToArray();
        }

        public static PotionData[] SeedPotionData()
        {
            var potionData = System.IO.File.ReadAllText("Helpers/Seeds/SeedPotionData.json");
            var potions = JsonConvert.DeserializeObject<List<PotionData>>(potionData);

            return potions.ToArray();
        }
    }
}