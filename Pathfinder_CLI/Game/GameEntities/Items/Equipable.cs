using System;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public abstract class Equipable : Item, IEquipable
    {
        public int _currentDurability { get; set; }
        public int _maxDurability { get; set; }
        public Equipable(string name, int goldValue, int currentDurability, int maxDurability) : base(name, goldValue)
        {
            _name = name;
            _goldValue = goldValue;
            _currentDurability = currentDurability;
            _maxDurability = maxDurability;
        }
        public void DecreaseDurability(int points)
        {
            if (isBroken())
            {
                Console.WriteLine($"{_name} is broken! Repair it at a shop with the command 'repair <itemName>'.");
                NullifyValue();
                return;
            }
            _currentDurability -= points;
        }

        public void FullRepair()
        {
            _currentDurability = _maxDurability;
            Console.WriteLine($"{_name} has been repaired to {_currentDurability} / {_maxDurability} durability.");
        }

        public bool isBroken()
        {
            return _currentDurability <= 0 ? true : false;
        }


        // Use(character : ICharacterEntity)
        // Using an item will simply equip the item for the character.
        public override void Use(CharacterEntity character)
        {
            if (character._equipment.Insert(this))
            {
                Console.WriteLine($"{_name} equipped! Slots {character.GetEquipment()._items.Count} / {character.GetEquipment()._maxSlots} are being used.");
                character.RemoveItemFrom(character.GetInventory(), _name);
            }
        }
        public abstract void NullifyValue();
    }
}