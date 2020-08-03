using System;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public class Potion : Item, IConsumable
    {
        public int _healValue { get; set; }
        public Potion(string name, int goldValue, int healValue) : base(name, goldValue)
        {
            _healValue = healValue;
        }

        public override void Use(CharacterEntity character)
        {
            UseConsumable((ICombative)character);
            Console.WriteLine($"{_name} consumed. Healed for {_healValue}");
        }

        public void UseConsumable(ICombative character)
        {
            character.ConsumePotion(this);
        }
    }
}