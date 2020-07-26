using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Common.Interfaces
{
    public interface IItemContainer
    {

        string ToString();
        bool isFull();
        bool Insert(IInventoryItem item);
        bool InsertArray(IInventoryItem[] items);
        bool Remove(IInventoryItem item);
        IInventoryItem Find(string key);        
    }
}