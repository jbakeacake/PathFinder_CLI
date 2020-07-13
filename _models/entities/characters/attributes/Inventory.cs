using System.Collections.Generic;

namespace adventure_cli._models.entities.characters.attributes
{
    public class Inventory
    {
        private readonly int MAX_ITEMS = 4;
        public LinkedList<Entity> _Items;
        public Inventory()
        {
            _Items = new LinkedList<Entity>();
        }

        public Inventory(LinkedList<Entity> Items)
        {
            _Items = Items;
        }

        public override string ToString()
        {
            string toRtn = "\n---INVENTORY---\n";
            foreach(Entity item in _Items)
            {
                toRtn += $"{item._name} \n";
            }
            return toRtn;
        }

        public Entity GetItem(Entity item)
        {
            LinkedListNode<Entity> item_node = _Items.Find(item);
            if(_Items.Count == 0 || item_node == null) return null;
            
            Entity entityToReturn = item_node.Value;

            return entityToReturn;
        }


        public bool Insert(Entity item) 
        {
            if (_Items.Count >= MAX_ITEMS) return false;

            _Items.AddLast(new LinkedListNode<Entity>(item));

            return true;
        }

        public bool Remove(Entity item)
        {
            LinkedListNode<Entity> found = _Items.Find(item);

            if (_Items.Count == 0 || found == null) return false;

            _Items.Remove(found);

            return true;
        }
    }
}