using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Game.GameEntities.Characters
{
    public class CharacterEntity : ICharacterEntity
    {
        public string _name { get; set; }
        public string _type { get; set; }
        public Stats _stats { get; set; }
        public ItemContainer _inventory { get; set; }
        public ItemContainer _equipment { get; set; }
        public CharacterEntity(string name,
        string type,
        Stats stats,
        ItemContainer inventory,
        ItemContainer equipment)
        {
            _name = name;
            _type = type;
            _stats = stats;
            _inventory = inventory;
            _equipment = equipment;
        }

        public override string ToString()
        {
            return $"{_name} | Level : {_stats._level} | HP: {_stats._HP} / {_stats._maxHP}";
        }

        public Stats GetStats()
        {
            return _stats;
        }
        public void SetStats(Stats stats)
        {
            _stats = stats;
        }
        public ItemContainer GetEquipment()
        {
            return _equipment;
        }

        public void SetEquipment(ItemContainer equipment)
        {
            _equipment = equipment;
        }

        public ItemContainer GetInventory()
        {
            return _inventory;
        }
        public void SetInventory(ItemContainer inventory)
        {
            _inventory = inventory;
        }

        public string GetName()
        {
            return _name;
        }
        
        public string CurrentHealthToString()
        {
            var message = $"{_name}: {_stats._HP}/{_stats._maxHP}";
            return message;
        }
        public void RemoveItemFrom(ItemContainer container, string itemName)
        {
            if (container.Remove(itemName))
            {
                Console.WriteLine($"{itemName} removed from your {container._name}.");
            }
            else
            {
                Console.WriteLine($"{itemName} could not be found.");
            }
        }

        public void InsertItemInto(ItemContainer container, Item item)
        {
            if (container.Insert(item))
            {
                Console.WriteLine($"{item._name} was placed in your {container._name}");
            }
            else
            {
                Console.WriteLine($"{item._name} can't be placed in your {container._name}! Remove some items with the 'remove <itemName>' command.");
            }
        }
    }
}