using System;
using System.Collections.Generic;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Common.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Tests.Helpers
{
    public static class TestingUtils
    {
        public static Stats GetRandomStats()
        {
            Random rand = new Random();
            Skill str, dex, intelli;
            str = new Skill("Strength", rand.Next(10));
            dex = new Skill("Dexterity", rand.Next(10));
            intelli = new Skill("Intelligence", rand.Next(10));

            int maxHP = rand.Next(20);
            int HP = maxHP;
            int XP = rand.Next(100);
            int gold = rand.Next(100);

            Dictionary<string, Skill> skills = new Dictionary<string, Skill>();
            skills.Add(str.GetName(), str);
            skills.Add(dex.GetName(), dex);
            skills.Add(intelli.GetName(), intelli);


            Stats statsToReturn = new Stats(maxHP, HP, XP, gold, skills);
            return statsToReturn;
        }

        public static Dictionary<string, Skill> GenerateSkills(int strength, int dexterity, int intelligence)
        {
            Dictionary<string, Skill> skillsToReturn = new Dictionary<string, Skill>();
            skillsToReturn.Add("Strength", new Skill("Strength", strength));
            skillsToReturn.Add("Dexterity", new Skill("Dexterity", dexterity));
            skillsToReturn.Add("Intelligence", new Skill("Intelligence", intelligence));

            return skillsToReturn;
        }

        public static ItemContainer GenerateInventory()
        {
            ItemContainer inventoryToReturn = new ItemContainer(8, "INVENTORY");
            Weapon weapon = GenerateWeapon();
            Armor armor = GenerateArmor();
            Potion potion = GeneratePotion();

            inventoryToReturn.InsertArray(new IInventoryItem[] { weapon, armor, potion });
            return inventoryToReturn;
        }

        public static ItemContainer GenerateEquipment()
        {
            ItemContainer equipmentToReturn = new ItemContainer(4, "EQUIPMENT");
            Weapon weapon = GenerateWeapon();
            equipmentToReturn.Insert(weapon);
            return equipmentToReturn;
        }


        public static PlayerEntity GeneratePlayer()
        {

            PlayerEntity playerToReturn = new PlayerEntity("Player",
            "PLAYER",
            GetRandomStats(),
            GenerateInventory(),
            GenerateEquipment()
            );

            return playerToReturn;
        }

        public static EnemyEntity GenerateEnemy()
        {

            EnemyEntity enemyToReturn = new EnemyEntity("Player",
            "Enemy",
            GetRandomStats(),
            GenerateInventory(),
            GenerateEquipment()
            );

            return enemyToReturn;
        }
        public static Weapon GenerateWeapon()
        {
            return new Weapon("weapon", 1, 5, 5, 999, 999);
        }

        public static Armor GenerateArmor()
        {
            return new Armor("armor", 1, 999, 5, 5);
        }

        public static Potion GeneratePotion()
        {
            return new Potion("potion", 1, 999);
        }
    }
}