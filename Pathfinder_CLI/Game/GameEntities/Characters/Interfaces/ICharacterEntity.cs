using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Interfaces
{
    public interface ICharacterEntity
    {
        string ToString();
        string GetName();
        ItemContainer GetEquipment();
        ItemContainer GetInventory();
        void RemoveItemFrom(ItemContainer container, string itemName);
        void InsertItemInto(ItemContainer container, Item item);
    }
}