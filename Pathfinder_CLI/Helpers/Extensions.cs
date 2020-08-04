using System.Collections.Generic;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Helpers
{
    public static class Extensions
    {
        public static PlayerEntity ConfigurePlayer(this CharacterData data, ItemContainer inventory, ItemContainer equipment)
        {
            Dictionary<string, Skill> skills = new Dictionary<string, Skill>() {
                {"Strength", new Skill("Strength", data.Strength)},
                {"Dexterity", new Skill("Dexterity", data.Dexterity)},
                {"Intelligence", new Skill("Intelligence", data.Intelligence)},
            };
            Stats stats = new Stats(data.Max_HP, data.HP, data.XP, data.Gold, skills);
            PlayerEntity character = new PlayerEntity(data.Name,
                data.Type,
                stats,
                inventory,
                equipment);

            return character;
        }
        public static EnemyEntity ConfigureEnemy(this CharacterData data, ItemContainer inventory, ItemContainer equipment)
        {
            Dictionary<string, Skill> skills = new Dictionary<string, Skill>() {
                {"Strength", new Skill("Strength", data.Strength)},
                {"Dexterity", new Skill("Dexterity", data.Dexterity)},
                {"Intelligence", new Skill("Intelligence", data.Intelligence)},
            };
            Stats stats = new Stats(data.Max_HP, data.HP, data.XP, data.Gold, skills);
            EnemyEntity character = new EnemyEntity(data.Name,
                data.Type,
                stats,
                inventory,
                equipment);

            return character;
        }
    }
}