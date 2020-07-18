using System;
using System.Collections.Generic;
using adventure_cli._models.entities.items;

namespace adventure_cli._models.entities.characters.attributes
{
    public class Inventory<T> where T : Entity
    {
        public int _maxSlots { get; set; }
        public LinkedList<T> _Items;
        public string _name { get; set; }
        public Inventory(int maxSlots, string name)
        {
            _name = name;
            _maxSlots = maxSlots;
            _Items = new LinkedList<T>();
        }

        public Inventory(int maxSlots, string name, LinkedList<T> Items)
        {
            _name = name;
            _maxSlots = maxSlots;
            _Items = Items;
        }

        public override string ToString()
        {
            string toRtn = $"\n---{_name}---\n";
            foreach(T item in _Items)
            {
                toRtn += $"{item._name} \n";
            }
            return toRtn;
        }

        public Entity GetItem(T item)
        {
            LinkedListNode<T> item_node = _Items.Find(item);
            if(_Items.Count == 0 || item_node == null) return null;
            
            Entity entityToReturn = item_node.Value;

            return entityToReturn;
        }

        public bool IsFull()
        {
            return _Items.Count == _maxSlots;
        }

        public T FindItemByName(string name)
        {
            var itemToFind = name.ToLower().Trim();
            foreach(var item in _Items)
            {
                var currentItem = item._name.ToLower().Trim();
                if (currentItem == itemToFind)
                {
                    return item;
                }
            }

            return null;
        }

        public bool Insert(T item) 
        {
            if (_Items.Count >= _maxSlots) return false;

            _Items.AddLast(new LinkedListNode<T>(item));

            return true;
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> found = _Items.Find(item);

            if (_Items.Count == 0 || found == null) return false;

            _Items.Remove(found);

            return true;
        }
    }
}