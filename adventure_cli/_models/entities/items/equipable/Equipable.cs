using System;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.items.equipable
{
    public abstract class Equipable : Item
    {
        public int _maxDurability { get; set; }
        public int _currentDurability { get; set; }
        public Equipable(int Id, string name, int goldValue, int maxDurability) : base(Id, name, goldValue)
        {
            _maxDurability = maxDurability;
            _currentDurability = _currentDurability;
        }

        public override void Use(PlayerEntity player)
        {
            if (player._equipped.IsFull())
            {
                Console.WriteLine($"Equipment is full. Remove an item from your equipment before equipping {_name}");
            }
            else
            {
                Console.WriteLine($"{_name} equipped.");
                player._equipped.Insert(this);
                player._inventory.Remove(this);
            }
        }
        public void DecreaseDurability()
        {
            _currentDurability -= 1;
        }
        public void FullRepair()
        {
            _currentDurability = _maxDurability;
        }

        /**
        NullifyValue(void) -> void

        This method sets the gold value and any other attributes to zero, nullifying any effects
        that this equipable could have.

        */
        public abstract void NullifyValue();
    }
}