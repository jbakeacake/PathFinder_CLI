using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.actions
{
    public abstract class Option
    {
        public int _index;
        public string _name;
        public Option(int index, string name)
        {
            _index = index;
            _name = name;
        }
        public abstract void doAction(PlayerEntity player);
    }
}