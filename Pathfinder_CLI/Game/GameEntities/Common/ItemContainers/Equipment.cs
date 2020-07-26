using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Common.ItemContainers
{
    public class Equipment : ItemContainer
    {
        public Equipment(int maxSlots) : base(maxSlots)
        {
        }

        public Equipment(int maxSlots, IInventoryItem[] items) : base(maxSlots, items)
        {
        }
    }
}