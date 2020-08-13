using System;
using Pathfinder_CLI.Game.Commands.Attributes;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Modules
{
    public class InfoModule : ModuleBase<Context>
    {
        private readonly PlayerEntity _player;
        public InfoModule(IServiceProvider provider) : base(provider)
        {
            _player = _context._player;
        }

        [Command("inventory")]
        public void DisplayInventory()
        {
            SendMessage(_player._inventory.ToString());
        }

        [Command("equipment")]
        public void DisplayEquipment()
        {
            SendMessage(_player._equipment.ToString());
        }

        [Command("stats")]
        public void DisplayStats()
        {
            SendMessage(_player._stats.ToString());
        }

        [Command("use")]
        public void Use(string itemName)
        {
            var item = _player._inventory.Find(itemName);

            if(item == null)
            {
                SendMessage($"Could not find {itemName} in your inventory!");
                return;
            }
            item.Use(_player);
        }

        [Command("drop")]
        public void Drop(string itemName)
        {
            SendMessage($"Are you sure you want to drop {itemName}? (yes/no)");
            var res = Console.ReadLine();
            if(res.ToLower().Equals("yes"))
            {
                var success = _player._inventory.Remove(itemName);
                if(success)
                {
                    SendMessage($"{itemName} dropped.");
                }
                else
                {
                    SendMessage($"{itemName} could not be found in your inventory!");
                }
            }
        }

        [Command("unequip")]
        public void Unequip(string itemName)
        {
            var item = _player._equipment.Find(itemName);
            if(item != null)
            {
                _player.UnEquipItem((Equipable)item);
                SendMessage($"{itemName} unequipped, and placed in Inventory");
            }
            else
            {
                SendMessage($"{itemName} cannot be found in your equipment.");
            }
        }

        [Command("exit")]
        public void Exit()
        {
            SendMessage("Exiting...");
            Environment.Exit(0);
        }

        [Command("info")]
        public override void DisplayCommands()
        {
            SendMessage(@"Here's some basic commands you can use whenever: 
            > Inventory : Display all items in your inventory
            > Equipment : Display all items in your equipment
            > Stats : Display your stats
            > Use 'item name' : Equips/consumes an item from your inventory
            > Drop 'item name' : Removes an item from your inventory/equipment
            > Unequip 'item name' : Removes an item from you equipment and stores it in your inventory
            > Exit : Quit the game
            ");
        }
    }
}