using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinder_CLI.Game.GameEntities.Common.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Helpers;

namespace Pathfinder_CLI.Game.GameEntities.Common.ItemContainers
{
    public class ItemContainer : IItemContainer
    {
        public int _maxSlots { get; set; }
        public string _name { get; set; }
        public LinkedList<IInventoryItem> _items;
        public ItemContainer(int maxSlots, string name)
        {
            _maxSlots = maxSlots;
            _name = name;
            _items = new LinkedList<IInventoryItem>();
        }
        public ItemContainer(int maxSlots, string name, IInventoryItem[] items)
        {
            _maxSlots = maxSlots;
            _items = new LinkedList<IInventoryItem>();
            InsertArray(items);
            _name = name;
        }

        public override string ToString()
        {
            string toRtn = "";
            foreach (var item in _items)
            {
                toRtn += $"> {item.GetName()} \n";
            }
            return toRtn;
        }

        public IInventoryItem Find(string key)
        {
            var item = _items.FirstOrDefault(x => x.GetName().ToLower() == key.ToLower());
            return item;
        }

        public bool Remove(string key)
        {
            var lowercaseKey = key.ToLower();
            var item = Find(lowercaseKey);
            var isRemoved = _items.Remove(item);
            
            return isRemoved;
        }
        public bool Remove(IInventoryItem item)
        {
            return _items.Remove(item);
        }
        public bool Insert(IInventoryItem item)
        {
            if (isFull()) return false;

            _items.AddLast(item);
            return true;
        }
        public bool InsertArray(IInventoryItem[] items)
        {
            if (isFull() || items.Length + _items.Count > _maxSlots) return false;

            foreach (var item in items)
            {
                var isAdded = Insert(item);
                if (!isAdded)
                    return isAdded;
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