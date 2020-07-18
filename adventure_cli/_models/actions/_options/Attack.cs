using System;
using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items.equipable.weapon;

namespace adventure_cli._models.actions._options
{
    public class Attack : Option
    {
        public Weapon _weapon { get; set; }
        public EnemyEntity _enemy { get; set; }
        public Attack(int index, string name, Weapon weapon, EnemyEntity _enemy) : base(index, name)
        {
            _weapon = weapon;
        }

        public override void doAction(PlayerEntity player)
        {
            // First determine if the player can hit the enemy:
            if (_enemy.isHitDodged(player))
            {
                Console.WriteLine($"{_enemy._name} dodged the attack!");
            }
            else
            {
                // Total Damage is made up of two sources: the Player's strength, and the weapon being used
                Random rand = new Random();
                int damageFromWeapon = rand.Next(_weapon._minDamage, _weapon._maxDamage + 1); // '+ 1' since rand.Next(...) has an exclusive maximum
                int totalDamage = player._stats._skills["Strength"]._value + damageFromWeapon;
                Console.WriteLine($"{_enemy._name} took {totalDamage} points of damage!");
                _enemy.TakeDamage(totalDamage);
            }
        }
    }
}