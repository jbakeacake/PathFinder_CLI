using System;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class EnemyEntity : CharacterEntity, ICombatEntity
    {
        private Stats _tempStats;
        public EnemyEntity(int Id, string name, string type, Stats stats, Inventory<Item> inventory, Inventory<Equipable> equipment) : base(Id, name, type, stats, inventory, equipment)
        {
        }

        public void TakeDamage(int damage)
        {
            _stats._HP -= damage;
        }
        public bool isDead()
        {
            return _stats._HP <= 0 ? true : false;
        }

        private void UpdateModifiers(Stats stats)
        {
            stats._armorClass = _stats._skills["Strength"].GetModifier();
            stats._speed = _stats._skills["Dexterity"].GetModifier();
            stats._spellSlots = _stats._skills["Intelligence"].GetModifier();
        }

        public void ApplyDebuff(string skillToDebuff, int reductionValue)
        {
            _tempStats._skills[skillToDebuff]._value -= reductionValue;
            UpdateModifiers(_tempStats);
        }

        // isHitDodged(other : CharacterEntity) -> bool
        //
        // Determine whether or not this character has dodged an incoming attack. This is calculated by measuring
        // both the attacking and defending entity's speed. If one speed is higher, then that entity has a percentage
        // chance to dodge it; if one speed is lower than or equal, the entity being damage will 100% take the damage.
        public bool isHitDodged(ICombatEntity other)
        {
            // Before any damage is actually done, we have to determine whether the attack hits or not. This is dependent on both the player and the other's
            // speed. If each speed is on par with each other, the attack will hit no matter what; If one speed is higher, the entity with the higher
            // speed will have a chance to not be hit. This percentage will be based on difference of speed of each entity. E.g. 1 point higher : 10% chance to dodge,
            // 2 points higher : 20% to dodge, and so on.

            // First calculate the dodge chance of this entity:
            Random rand = new Random();
            int chanceToDodge = this._stats._speed - other.GetStats()._speed;
            if (chanceToDodge <= 0)
            {
                return false;
            }
            else
            {
                chanceToDodge *= 10; // Muliply by 10 to obtain our percentage chance
                // Now roll a die to determine if the attack hits:
                int rollToHit = rand.Next(0, 100);
                int hitMargin = 100 - chanceToDodge;
                if (rollToHit < hitMargin) // If the number rolled is in the HIT margin, return false (i.e. 0... (100 - chanceToDodge))
                {
                    return false;
                }
                else // If the number rolled is in the MISS margin, return true (i.e. chanceToDodge... 100)
                {
                    return true;
                }
            }
        }

        public void AttackOther(ICombatEntity other, Weapon weapon)
        {
            if (other.isHitDodged(this)) // Check if the other can dodge an attack from THIS entity
            {
                Console.WriteLine($"{other.GetName()} dodged the attack!");
            }
            else
            {
                // Total Damage is made up of two sources: the Player's strength, and the weapon being used
                Random rand = new Random();
                int damageFromWeapon = rand.Next(weapon._minDamage, weapon._maxDamage + 1); // '+ 1' since rand.Next(...) has an exclusive maximum
                int totalDamage = _stats._skills["Strength"]._value + damageFromWeapon - other.GetStats()._armorClass;
                if (totalDamage < 0)
                {
                    totalDamage = 0;
                }
                weapon._currentDurability--;
                other.TakeDamage(totalDamage);
                
                Console.WriteLine($"{other.GetName()} took {totalDamage} points of damage! ({other.GetName()} HP: {other.GetStats()._HP} / {other.GetStats()._maxHP})");
            }
        }
        public Stats GetStats()
        {
            return _stats;
        }

        public string GetName()
        {
            return _name;
        }

        public void Defend(Armor armor)
        {
            _tempStats._armorClass += armor._armorRating;
            armor._currentDurability--;
        }
    }
}