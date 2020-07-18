using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items;

namespace adventure_cli._models.actions.commands
{
    public static class GeneralCommands
    {
        public static void doCommand(string command, PlayerEntity player)
        {
            command = command.ToLower();
            var keyParts = command.Split(' ');
            var action = keyParts[0];
            switch (action)
            {
                case "exit":
                    {
                        Exit();
                        break;
                    }
                case "inventory":
                    {
                        Inventory(player);
                        break;
                    }
                case "stats":
                    {
                        Stats(player);
                        break;
                    }
                case "use":
                    {
                        var item = GetItemInInventory(keyParts, player);
                        item.Use(player);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Command. Type 'commands' to list out all possible commands");
                        break;
                    }
            }
        }

        private static Item GetItemInInventory(string[] keyParts, PlayerEntity player)
        {
            string itemName = "";
            for (int i = 1; i < keyParts.Length; i++)
            {
                itemName += keyParts[i] + " ";
            }
            return player._inventory.FindItemByName(itemName);
        }
        private static void Exit()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0); // Exit the user from the application
        }

        private static void Inventory(PlayerEntity player)
        {
            Console.WriteLine(player._inventory.ToString());
        }

        private static void Stats(PlayerEntity player)
        {
            Console.WriteLine(player._stats.ToString());
        }

        private static void Use(Item item, PlayerEntity player)
        {
            item.Use(player);
        }
    }
}