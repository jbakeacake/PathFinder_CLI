using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Interfaces
{
    public interface ICharacterEntity
    {
        string ToString();
        string GetName();
        Equipment GetEquipment();
        Inventory GetInventory();
    }
}