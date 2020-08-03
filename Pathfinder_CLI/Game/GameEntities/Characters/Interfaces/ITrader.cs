using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Interfaces
{
    public interface ITrader
    {
        void BuyFromOther(CharacterEntity other, Item item);
        void SellToOther(CharacterEntity other, Item item);
        ItemContainer GetInventory();
        void SetInventory(ItemContainer inventory);
    }
}