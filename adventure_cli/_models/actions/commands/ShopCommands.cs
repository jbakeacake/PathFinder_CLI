using System;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items;

namespace adventure_cli._models.actions.commands
{
    public static class ShopCommands
    {
        public static void doCommand(string command, PlayerEntity player, CharacterEntity shopkeep)
        {
            command = command.ToLower();
            var keyParts = command.Split(' ');
            for (int i = 0; i < keyParts.Length; i++)
            {
                keyParts[i] = keyParts[i].Trim();
            }
            var action = keyParts[0];
            switch (action)
            {
                case "buy":
                    {
                        string itemName = keyParts[1];
                        BuyItemInShop(player, shopkeep, itemName);
                        break;
                    }
                case "sell":
                    {
                        string itemName = keyParts[1];
                        SellItemInShop(player, shopkeep, itemName);
                        break;
                    }
            }
        }

        private static void BuyItemInShop(PlayerEntity player, CharacterEntity shopkeep, string itemName)
        {
            var item = shopkeep._inventory.FindItemByName(itemName);
            //First check if the player has enough gold, and has enough space for the item
            if (player._stats._gold < item._goldValue || player._inventory.IsFull())
            {
                Console.WriteLine("Unable to buy item. Check if you have enough space in your inventory, or that you have enough money.");
                return;
            }
            player._stats._gold -= item._goldValue;
            player._inventory.Insert(item);
            // Output to console:
            Console.WriteLine($"{shopkeep._name}: {shopkeep._name} appreciates your coin. Here is your {item._name}.");
            Console.WriteLine($"You obtain {item._name}.");
        }

        private static void SellItemInShop(PlayerEntity player, CharacterEntity shopkeep, string itemName)
        {
            var item = player._inventory.FindItemByName(itemName);
            if (item == null) return;

            player._stats._gold += item._goldValue;
            player._inventory.Remove(item);
            shopkeep._inventory.Insert(item);
            // Output to console:
            Console.WriteLine($"{shopkeep._name}: {shopkeep._name} appreciates your {item._name}. Here is your coin.");
            Console.WriteLine($"You obtain {item._goldValue}gp.");
        }
    }
}