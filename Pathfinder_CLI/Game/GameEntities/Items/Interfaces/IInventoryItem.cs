using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items.Interfaces
{
    public interface IInventoryItem
    {
        string GetName();
        void Use(ICharacterEntity character);
    }
}