using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Helpers
{
    public class TradingHelper : ITrader
    {
        public Stats _stats { get; set; }
        public ItemContainer _inventory { get; set; }
        public TradingHelper(Stats stats, ItemContainer inventory)
        {
            _stats = stats;
            _inventory = inventory;
        }
        public void BuyFromOther(CharacterEntity other, Item item)
        {
            if (CanBuy(item))
            {
                TradeItemWith(other, item);
                RemoveItemGoldValue(item);
            }
        }

        public void SellToOther(CharacterEntity other, Item item)
        {
            // Given that the other trader is also checking if they can buy the item,
            // there is no need to check if the other can buy the item we're selling
            TradeItemWith(other, item);
            AddItemGoldValue(item);
        }

        private void AddItemGoldValue(Item item)
        {
            _stats._gold += item._goldValue;
        }

        private void RemoveItemGoldValue(Item item)
        {
            _stats._gold -= item._goldValue;
        }

        private bool CanBuy(Item item)
        {
            return _stats._gold >= item._goldValue ? true : false;
        }

        private void TradeItemWith(CharacterEntity other, Item item)
        {
            var otherInventory = other.GetInventory();

            if (!otherInventory.isFull())
            {
                otherInventory.Insert(item);
                _inventory.Remove(item);
            }
            else
            {
                Console.WriteLine($"{other._name}'s inventory is full! I can't trade.");
            }
        }

        public ItemContainer GetInventory()
        {
            return _inventory;
        }

        public void SetInventory(ItemContainer inventory)
        {
            _inventory = inventory;
        }
    }
}