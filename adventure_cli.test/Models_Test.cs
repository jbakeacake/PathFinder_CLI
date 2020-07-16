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

namespace adventure_cli.test
{
    public class Models_Test
    {
        private readonly PlayerEntity _player;
        private readonly ITestOutputHelper _output;

        public Models_Test(ITestOutputHelper output)
        {
            _output = output;

            Inventory inv = new Inventory();

            Dictionary<string, Stat> skills = new Dictionary<string, Stat>();
            skills.Add("Strength", new Strength(2));
            skills.Add("Dexterity", new Dexterity(2));
            skills.Add("Intelligence", new Intelligence(2));

            Stats stats = new Stats(maxHP: 10, XP: 0, gold: 100,level: 0, skills);

            _player = new PlayerEntity(999, "DJANGO", "Player", stats, inv);
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
            Assert.True(_player._inventory.Insert(new Potion(1, "Lesser Healing Potion", 100, 5)));
            Assert.True(_player._inventory.Insert(new Weapon(1, "Iron Longsword", 150, 5, 2, 4)));
            Assert.True(_player._inventory.Insert(new Armor(1, "Leather Armor", 120, 5)));

            _output.WriteLine("Printing Inventory...");
            _output.WriteLine(_player._inventory.ToString());
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
            Entity weapon = new Weapon(1, "Iron Longsword", 150, 5, 2, 4);

            Assert.True(_player._inventory.Insert(new Potion(1, "Lesser Healing Potion", 100, 5)));
            Assert.True(_player._inventory.Insert(weapon));
            Assert.True(_player._inventory.Insert(new Armor(1, "Leather Armor", 120, 5)));

            _output.WriteLine("\nPrinting Inventory before removal...");
            _output.WriteLine(_player._inventory.ToString());

            Assert.True(_player._inventory.Remove(weapon));
            Assert.False(_player._inventory.Remove(new Potion(1, "Lesser Healing Potion", 100, 5))); // Should return null on "Find(...)" call

            _output.WriteLine("Printing Inventory after removal...");
            _output.WriteLine(_player._inventory.ToString());
        }

        [Fact]
        public void Inventory_GetItem()
        {
            Entity weapon = new Weapon(1, "Iron Longsword", 150, 5, 2, 4);
            Assert.True(_player._inventory.Insert(weapon));

            Assert.True(_player._inventory.GetItem(weapon) == weapon);
            Assert.False(_player._inventory.GetItem(weapon) == new Weapon(1, "Iron Longsword", 150, 5, 2, 4));
        }
    }
}
