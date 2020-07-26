using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public class Armor : Equipable
    {
        public int _armorRating { get; set; }
        public Armor(string name, int goldValue, int armorRating, int currentDurability, int maxDurability) : base(name, goldValue, currentDurability, maxDurability)
        {
            _armorRating = armorRating;
        }

        public int GetArmorRating()
        {
            if(isBroken())
            {
                Console.WriteLine($"{_name} is broken!");
                return 0;
            }
            return _armorRating;
        }

        public override void NullifyValue()
        {
            Console.WriteLine($"{_name} is broken!");
            _armorRating = 0;
            _goldValue = 0;
        }
    }
}