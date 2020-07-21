using System;
using Xunit;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.characters.attributes;
using System.Collections.Generic;
using adventure_cli._models.entities.characters.attributes.stat_types;
using adventure_cli._models.player.attributes;
using adventure_cli._models.entities.items.consumable;
using Xunit.Abstractions;
using adventure_cli._models.entities.items.equipable.weapon;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;

namespace adventure_cli.test
{
    public class Models_Test
    {
        private readonly PlayerEntity _player;
        private readonly ITestOutputHelper _output;

        public Models_Test(ITestOutputHelper output)
        {
            _output = output;

            Inventory<Item> inv = new Inventory<Item>(8, "INVENTORY");
            Inventory<Equipable> equipment = new Inventory<Equipable>(4, "EQUIPMENT");

            Dictionary<string, Stat> skills = new Dictionary<string, Stat>();
            skills.Add("Strength", new Strength(5));
            skills.Add("Dexterity", new Dexterity(3));
            skills.Add("Intelligence", new Intelligence(2));

            Stats stats = new Stats(maxHP: 10, XP: 0, gold: 100,level: 0, skills);

            _player = new PlayerEntity(999, "DJANGO", "Player", stats, inv, equipment);
        }

        [Fact]
        public void PlayerExists()
        {
            Assert.True(_player != null);
            _output.WriteLine($"\n\nName : {_player.ToString()}");

            _output.WriteLine("\nPrinting Stats...");
            _output.WriteLine(_player._stats.ToString());
        }

        [Fact]
        public void Player_IncreaseSkill()
        {
            //Given the user levels up, they will be given 1 skill point to invest into a skill (Str, Dex, Int)
            int beforeIncrease = _player._stats._skills["Strength"]._value;
            _player.IncreaseSkill("Strength", 1);

            //When a skill is increased, it should be reflected in the players stats.ToString()
            _output.WriteLine("\nPrinting Stats...");
            _output.WriteLine(_player._stats.ToString());

            //Test if the user's skill has actually increased:
            Assert.True(_player._stats._skills["Strength"]._value == beforeIncrease + 1);
        }

        [Fact]
        public void Player_CanLevelUp()
        {
        //Given the user has enough experience, determine if it can level up
        _player._stats._XP = 110; // The initial cap is 100 for the 1st level

        //Whenever the user finishes an event and has gained experience, determine if they can level up
        Assert.True(_player.CanLevelUp());

        //Then the user's _maxXP cap should be raised
        _player.IncreaseXPCap();
        Assert.False(_player.CanLevelUp());
        }

        [Fact]
        public void Inventory_Insert()
        {
            Assert.True(_player._inventory.Insert(new Potion(1, "Potion", 100, 5)));
            Assert.True(_player._inventory.Insert(new Weapon(1, "Longsword", 150, 5, 2, 4)));
            Assert.True(_player._inventory.Insert(new Armor(1, "Leather Buckler", 120, 2, 5)));
        }

        [Fact]
        public void Inventory_Remove()
        {
            //In this test, we must assume that we are able to 'select' an item in the user's inventory
            //before removing it. Think of the actions in this order:
            //
            // User opens inventory -> User selects Entity item in inventory -> a list options are displayed for that item -> user chooses to remove item
            //
            //With that assumption and process in mind, we should be able to get a handle on the Entity item that's in the user's inventory. So, we should be able
            //to search for the node containing that Entity, then remove that linked list node from the user's inventory.
            //
            Item weapon = new Weapon(1, "Iron Longsword", 150, 5, 2, 4);

            Assert.True(_player._inventory.Insert(new Potion(1, "Lesser Healing Potion", 100, 5)));
            Assert.True(_player._inventory.Insert(weapon));
            Assert.True(_player._inventory.Insert(new Armor(1, "Leather Buckler", 120, 2, 5)));

            _output.WriteLine("\nPrinting Inventory before removal...");
            _output.WriteLine(_player._inventory.ToString());

            Assert.True(_player._inventory.Remove(weapon));
            Assert.False(_player._inventory.Remove(new Potion(1, "Potion", 100, 10))); // Should return null on "Find(...)" call

            _output.WriteLine("Printing Inventory after removal...");
            _output.WriteLine(_player._inventory.ToString());
        }

        [Fact]
        public void Inventory_GetItem()
        {
            Item weapon = new Weapon(1, "Iron Longsword", 150, 5, 2, 4);
            Assert.True(_player._inventory.Insert(weapon));

            Assert.True(_player._inventory.GetItem(weapon) == weapon);
        }

        [Fact]
        public void Stats_Modifiers()
        {
            // For reference, the stats + modifiers are:
            // {
            //     Strength : 5 -> modifier of 3
            //     Dexterity : 3 -> modifier of 2
            //     Intelligence : 2 -> modifier of 1
            // }
            Assert.True(_player._stats._skills["Strength"].GetModifier() == 3);
            Assert.True(_player._stats._speed == 2);
            Assert.True(_player._stats._spellSlots == 1);
        }

        [Fact]
        public void Weapon_Tests()
        {
            Weapon weapon = new Weapon(1, "Longsword", 100, 3, 3, 3);
            Assert.True(weapon.GetDamage() == 3);
            weapon.DecreaseDurability();
            weapon.DecreaseDurability();
            weapon.DecreaseDurability();
            Assert.True(weapon._currentDurability == 0);
            Assert.True(weapon._goldValue == 0);
            Assert.True(weapon._maxDurability == 3);
            Assert.True(weapon.GetDamage() == 0);
        }
    }
}
