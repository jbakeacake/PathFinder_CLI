using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public abstract class Item : IInventoryItem
    {
        public int _goldValue { get; set; }
        public string _name { get; set; }

        public string GetName()
        {
            return _name;
        }

        public abstract void Use(ICharacterEntity character);
    }
}