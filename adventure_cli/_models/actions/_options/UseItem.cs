using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items;

namespace adventure_cli._models.actions._options
{
    public class UseItem : Option
    {
        public Item _item { get; set; }
        public UseItem(int index, string name, Item item) : base(index, name)
        {
            _item = item;
        }

        public override void doAction(PlayerEntity player)
        {
            _item.Use(player);
        }
    }
}