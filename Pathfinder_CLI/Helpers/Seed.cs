using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pathfinder_CLI.Data;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Helpers
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Character_Tbl.Any())
            {
                var players = FormatJsonToList<CharacterData>("SeedPlayerData.json");
                var enemies = FormatJsonToList<CharacterData>("SeedEnemyData.json");
                var weapons = FormatJsonToList<WeaponData>("SeedWeaponData.json");
                var armors = FormatJsonToList<ArmorData>("SeedArmorData.json");
                var potions = FormatJsonToList<PotionData>("SeedPotionData.json");

                AddArrayToTable(context, players);
                AddArrayToTable(context, enemies);
                AddArrayToTable(context, weapons);
                AddArrayToTable(context, armors);
                AddArrayToTable(context, potions);
                context.SaveChanges();
            }
        }

        private static void AddArrayToTable<T>(DataContext context, List<T> list)
        {
            foreach(var item in list)
            {
                context.Add(item);
            }
        }

        private static List<T> FormatJsonToList<T>(string fileName)
        {
            var baseDir = Directory.GetCurrentDirectory() + "/Helpers/Seeds/";
            var data = System.IO.File.ReadAllText(baseDir + fileName);
            var listToReturn = JsonConvert.DeserializeObject<List<T>>(data);
            return listToReturn;
        }
    }
}