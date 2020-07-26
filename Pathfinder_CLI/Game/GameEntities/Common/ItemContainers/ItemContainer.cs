using System;
using System.Collections.Generic;
using Pathfinder_CLI.Game.GameEntities.Common.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Common.ItemContainers
{
    public abstract class ItemContainer : IItemContainer
    {
        public int _maxSlots { get; set; }
        public Dictionary<string, IInventoryItem> _items;
        public ItemContainer(int maxSlots)
        {
            _maxSlots = maxSlots;
        }
        public ItemContainer(int maxSlots, IInventoryItem[] items)
        {
            _maxSlots = maxSlots;
            InsertArray(items);
        }

        public IInventoryItem Find(string key)
        {
            return _items[key];
        }

        public bool Remove(string key)
        {
            var lowercaseKey = key.ToLower();
            if (!_items.ContainsKey(lowercaseKey)) return false;

            _items.Remove(lowercaseKey);

            return true;
        }
        public bool Remove(IInventoryItem item)
        {
            var lowercaseKey = item.GetName().ToLower();
            if (!_items.ContainsKey(lowercaseKey)) return false;

            _items.Remove(lowercaseKey);

            return true;
        }
        public bool Insert(IInventoryItem item)
        {
            if (isFull()) return false;

            string lowercaseKey = item.GetName().ToLower();
            _items.Add(lowercaseKey, item);
            return true;
        }
        public bool InsertArray(IInventoryItem[] items)
        {
            if (isFull() || items.Length + _items.Count > _maxSlots) return false;

            foreach (var item in items)
            {
                Insert(item);
            }

            return true;
        }
        public bool isFull()
        {
            if (_items.Count >= _maxSlots)
            {
                Console.WriteLine("Inventory is full! Drop some items with command, 'drop <itemName>'");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}