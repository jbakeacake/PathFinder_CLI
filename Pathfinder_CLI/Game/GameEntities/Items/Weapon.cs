using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public class Weapon : Equipable
    {
        public int _minDamage { get; set; }
        public int _maxDamage { get; set; }
        public Weapon(string name, int goldValue, int currentDurability, int maxDurability, int minDamage, int maxDamage) : base(name, goldValue, currentDurability, maxDurability)
        {
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }

        public int GetDamage()
        {
            if(isBroken())
            {
                Console.WriteLine($"{_name} is broken!");
                return 0;
            }
            
            Random rand = new Random();
            int rollForDamage = rand.Next(_minDamage, _maxDamage + 1); // exclusive max
            return rollForDamage;
        }

        public override void NullifyValue()
        {
            Console.WriteLine($"{_name} is broken!");
            _goldValue = 0;
            _minDamage = 0;
            _maxDamage = 0;
        }
    }
}