using Pathfinder_CLI.Game.GameEntities.Items;
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
            Potion potion = new Potion();
        }
    }
}