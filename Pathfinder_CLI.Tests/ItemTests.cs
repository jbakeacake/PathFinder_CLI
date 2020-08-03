using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Tests.Helpers;
using Xunit;

namespace Pathfinder_CLI.Tests
{
    public class ItemTests
    {
        [Fact]
        public void Armor_Test()
        {
            Armor armor = new Armor(name: "armor", 
            goldValue: 100,
            armorRating: 3,
            currentDurability: 3,
            maxDurability: 3);
            
            Assert.True(armor.GetArmorRating() == 3);
            armor.DecreaseDurability(3);
            Assert.True(armor.isBroken());
            armor.FullRepair();
            Assert.True(armor._currentDurability == armor._maxDurability);
        }

        [Fact]
        public void Weapon_Test()
        {
            Weapon weapon = new Weapon(name: "weapon",
            goldValue: 100,
            currentDurability: 3,
            maxDurability: 3,
            minDamage: 3,
            maxDamage: 3);

            Assert.True(weapon.GetDamage() == 3);
            weapon.DecreaseDurability(3);
            Assert.True(weapon.isBroken());
            weapon.FullRepair();
            Assert.True(weapon._currentDurability == weapon._maxDurability);
        }

        [Fact]
        public void Potion_Test()
        {
            Potion potion = TestingUtils.GeneratePotion();
            Stats stats = TestingUtils.GetRandomStats();
            ItemContainer inv = new ItemContainer(8, "INVENTORY", new IInventoryItem[]{potion});
            ItemContainer equipment = TestingUtils.GenerateEquipment();
            PlayerEntity player = new PlayerEntity("player", "PLAYER", stats, inv, equipment);
            
            player._stats._HP -= potion._healValue;
            Assert.False(player._stats._HP == player._stats._maxHP);
            
            potion.Use(player);
            
            Assert.True(player._stats._HP == player._stats._maxHP);
        }
    }
}