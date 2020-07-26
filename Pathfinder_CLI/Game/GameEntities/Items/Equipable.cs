using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public abstract class Equipable : IEquipable, IInventoryItem
    {
        public string _name { get; set; }
        public int _goldValue { get; set; }
        public int _currentDurability { get; set; }
        public int _maxDurability { get; set; }
        public Equipable(string name, int goldValue, int currentDurability, int maxDurability)
        {
            _name = name;
            _goldValue = goldValue;
            _currentDurability = currentDurability;
            _maxDurability = maxDurability;
        }
        public void DecreaseDurability(int points)
        {
            _currentDurability -= points;
            if (isBroken())
            {
                Console.WriteLine($"{_name} is broken! Repair it at a shop with the command 'repair <itemName>'.");
                NullifyValue();
            }
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
        public string GetName()
        {
            return _name;
        }

        // Use(character : ICharacterEntity)
        // Using an item will simply equip the item for the character.
        public void Use(ICharacterEntity character)
        {
            if (character.GetEquipment().Insert(this))
            {
                Console.WriteLine($"{_name} equipped! Slots {character.GetEquipment()._items.Count} / {character.GetEquipment()._maxSlots} are being used.");
                character.GetInventory().Remove(this);
            }
        }

        public abstract void NullifyValue();
    }
}