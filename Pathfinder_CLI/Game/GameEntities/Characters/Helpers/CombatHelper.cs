using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Spells.Types;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Helpers
{
    public class CombatHelper : ICombative
    {
        public ICombative _character { get; set; }
        public Stats _combatStats { get; set; }
        private Stats _stats { get; set; }
        private ItemContainer _inventory { get; set; }
        private string _name { get; set; }
        public CombatHelper(ICombative character, string name, Stats stats, ItemContainer inventory)
        {
            _character = character;
            _combatStats = stats;

        }
        public void CombatAction(ICombative other, Equipable equippedItem)
        {
            if (equippedItem is Weapon)
            {
                Attack(other, (Weapon)equippedItem);
            }
            else if (equippedItem is Armor)
            {
                Defend((Armor)equippedItem);
            }
        }

        public Stats GetCombatStats()
        {
            return _combatStats;
        }

        public void UpdateCharacterStats()
        {
            ResetCombatStatModifiers();
            _stats = _combatStats;
        }

        private void ResetCombatStatModifiers()
        {
            _combatStats._armorClass = _stats._armorClass;
            _combatStats._speed = _stats._speed;
            _combatStats._baseDamage = _stats._baseDamage;
        }
        public void TakeDamage(int damage)
        {
            var updatedHP = _character.GetCombatStats()._HP - damage;
            _combatStats.SetHP(updatedHP);
        }

        private void Attack(ICombative other, Weapon weapon)
        {
            if (isHitSuccessful(other))
            {
                var totalDamage = weapon.GetDamage() + _character.GetCombatStats().GetBaseDamage() - other.GetCombatStats().GetArmorClass();
                other.TakeDamage(totalDamage);
                Console.WriteLine($"{other.GetName()} took {totalDamage} points of damage!");
            }
            else
            {
                Console.WriteLine($"{other.GetName()} dodged the attack!");
            }
        }

        private void Defend(Armor armor)
        {
            var updatedArmorClass = _combatStats.GetArmorClass() + armor.GetArmorRating();
            _combatStats.SetArmorClass(updatedArmorClass);
        }

        private bool isHitSuccessful(ICombative other)
        {
            // The difference between speeds determines how large the hit margin is / how small the dodge margin is
            int speedDifference = _character.GetCombatStats().GetSpeed() - other.GetCombatStats().GetSpeed();
            // Having a speed difference less than or equal to 0 will result in a definite hit
            if(speedDifference < 0)
                speedDifference = 0;
 
            Random rand = new Random();
            int rollToHit = rand.Next(101);
            int hitMargin = 100 - (speedDifference * 10); // Hit Successful; We use '<' because a 100 roll is always going to hit

            if (rollToHit < hitMargin) // Hit Successful
            {
                return true;
            }
            else // Hit Missed
            {
                return false;
            }
        }

        public void ConsumePotion(Potion potion)
        {
            var updatedHP = _stats._HP + potion._healValue;
            var maxHP = _stats._maxHP;

            if (isOverhealed(updatedHP, maxHP))
                updatedHP = maxHP;
            _stats._HP = updatedHP;

            _inventory.Remove(potion);
        }

        private bool isOverhealed(int updatedHP, int maxHP)
        {
            return updatedHP >= maxHP ? true : false;
        }

        public bool isDead()
        {
            return _combatStats.GetHP() <= 0;
        }

        public void receiveDebuff(DebuffSpell debuff)
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            return _name;
        }
    }
}