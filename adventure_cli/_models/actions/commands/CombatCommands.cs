using System;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;

namespace adventure_cli._models.actions.commands
{
    public static class CombatCommands
    {
        public static bool doCommand(string command, PlayerEntity player, EnemyEntity enemy)
        {
            command = command.ToLower();
            var keyParts = command.Split(' ');
            var action = keyParts[0];
            switch (action)
            {
                case "attack":
                    {
                        var weapon = GetItemInEquipment(keyParts, player);
                        if (weapon == null || weapon.GetType() != typeof(Weapon))
                        {
                            Console.WriteLine($"You can't attack with that!");
                            return false;
                        }
                        else
                        {
                            Attack(player, enemy, (Weapon)weapon);
                            return true;
                        }
                    }
                case "defend":
                    {
                        var armor = GetItemInEquipment(keyParts, player);
                        if (armor == null || armor.GetType() != typeof(Armor))
                        {
                            Console.WriteLine($"You can't defend with that!");
                            return false;
                        }
                        else
                        {
                            Defend(player, (Armor)armor);
                            return true;
                        }
                    }
                case "use":
                    {
                        var item = GetItemInInventory(keyParts, player);
                        if (item == null) return false;
                        item.Use(player);
                        return true;
                    }
                case "inventory":
                    {
                        Inventory(player);
                        break;
                    }
                case "remove":
                    {
                        RemoveItemInEquipment(keyParts, player);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please enter a valid command. Type 'help' for a list of valid commands.");
                        return false;
                    }
            }
            return false;
        }

        private static void Defend(PlayerEntity player, Armor armor)
        {
            player.Defend(armor);
        }

        private static void Attack(PlayerEntity player, EnemyEntity enemy, Weapon weapon)
        {
            player.AttackOther(enemy, weapon);
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

        private static Equipable GetItemInEquipment(string[] keyParts, PlayerEntity player)
        {
            string itemName = "";
            for (int i = 1; i < keyParts.Length; i++)
            {
                itemName += keyParts[i] + " ";
            }
            var itemInEquipment = player._equipped.FindItemByName(itemName);
            if (itemInEquipment == null)
            {
                Console.WriteLine($"{itemName} could not be found!");
                return null;
            }
            return itemInEquipment;
        }

        private static void Inventory(PlayerEntity player)
        {
            Console.WriteLine(player._inventory.ToString());
        }

        private static void Use(Item item, PlayerEntity player)
        {
            item.Use(player);
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
    }
}