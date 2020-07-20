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
                case "equipment":
                    {
                        Equipment(player);
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
                        if (item == null) return;
                        item.Use(player);
                        break;
                    }
                case "remove":
                    {
                        RemoveItemInEquipment(keyParts, player);
                        break;
                    }
                default:
                    {
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
            var itemInInventory = player._inventory.FindItemByName(itemName);
            if (itemInInventory == null)
            {
                Console.WriteLine($"{itemName} could not be found!");
                return null;
            }
            return itemInInventory;
        }

        private static void RemoveItemInEquipment(string[] keyParts, PlayerEntity player)
        {
            string itemName = "";
            for (int i = 1; i < keyParts.Length; i++)
            {
                itemName += keyParts[i] + " ";
            }
            var equippedItem = player._equipped.FindItemByName(itemName);

            if (equippedItem == null)
            {
                Console.WriteLine($"{itemName} could not be found!");
                return;
            }

            Console.WriteLine($"{equippedItem._name} unequipped, and added to inventory.");
            player._equipped.Remove(equippedItem);
            player._inventory.Insert(equippedItem);
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

        private static void Equipment(PlayerEntity player)
        {
            Console.WriteLine(player._equipped.ToString());
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