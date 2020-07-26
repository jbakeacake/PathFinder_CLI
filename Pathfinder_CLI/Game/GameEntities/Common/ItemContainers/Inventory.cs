using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinder_CLI.Game.GameEntities.Common.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Common.ItemContainers
{
    public class Inventory : ItemContainer
    {
        public Inventory(int maxSlots) : base(maxSlots)
        {
        }

        public Inventory(int maxSlots, IInventoryItem[] items) : base(maxSlots, items)
        {
        }
    }
}