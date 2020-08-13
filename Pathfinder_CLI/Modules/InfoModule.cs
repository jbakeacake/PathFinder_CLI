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

        [Command("inventory", isInfoMethod: true)]
        public bool DisplayInventory()
        {
            SendMessage(_player._inventory.ToString());
            return true;
        }

        [Command("equipment", isInfoMethod: true)]
        public bool DisplayEquipment()
        {
            SendMessage(_player._equipment.ToString());
            return true;
        }

        [Command("stats", isInfoMethod: true)]
        public bool DisplayStats()
        {
            SendMessage(_player._stats.ToString());
            return true;
        }

        [Command("use", isInfoMethod: true)]
        public bool Use(string itemName)
        {
            var item = _player._inventory.Find(itemName);

            if(item == null)
            {
                SendMessage($"Could not find {itemName} in your inventory!");
                return false;
            }
            item.Use(_player);
            return true;
        }

        [Command("drop", isInfoMethod: true)]
        public bool Drop(string itemName)
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
            return true;
        }

        [Command("unequip", isInfoMethod: true)]
        public bool Unequip(string itemName)
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
            return true;
        }

        [Command("exit", isInfoMethod: true)]
        public bool Exit()
        {
            SendMessage("Exiting...");
            Environment.Exit(0);
            return true;
        }

        [Command("info", isInfoMethod: true)]
        public override bool DisplayCommands()
        {
            SendMessage(@"Here's some basic commands you can use whenever: 
            > commands : Display a list of commands you can use whenever
            > combat : Display a list of commands you can use during/at the end of combat
            > Inventory : Display all items in your inventory
            > Equipment : Display all items in your equipment
            > Stats : Display your stats
            > Use 'item name' : Equips/consumes an item from your inventory
            > Drop 'item name' : Removes an item from your inventory/equipment
            > Unequip 'item name' : Removes an item from you equipment and stores it in your inventory
            > Exit : Quit the game
            ");

            return true;
        }
    }
}