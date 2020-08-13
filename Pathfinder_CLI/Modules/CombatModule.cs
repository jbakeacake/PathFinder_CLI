using System;
using Microsoft.Extensions.DependencyInjection;
using Pathfinder_CLI.Game.Commands;
using Pathfinder_CLI.Game.Commands.Attributes;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Services;

namespace Pathfinder_CLI.Modules
{
    public class CombatModule : ModuleBase<CombatContext>
    {
        private PlayerEntity _player;
        private EnemyEntity _enemy;
        public CombatModule(IServiceProvider provider) : base(provider)
        {
            _player = _context._player;
            _enemy = _context._other as EnemyEntity;
        }

        [Command("attack")]
        public bool Attack(string weaponName)
        {
            var weapon = _player._equipment.Find(weaponName) as Weapon;
            if (weapon == null)
            {
                SendMessage($"{weaponName} not found in equipment!");
                return false;
            }
            _player.CombatAction(_enemy, weapon);
            return true;
        }

        [Command("defend")]
        public bool Defend(string armorName)
        {
            var armor = _player._equipment.Find(armorName) as Armor;
            if (armor == null)
            {
                SendMessage($"Invalid item: '{armorName}'!");
                return false;
            }
            _player.CombatAction(_enemy, armor);
            return true;
        }

        [Command("take", isInfoMethod: true)]
        public bool Take(string itemName)
        {
            var itemFromContext = _context.FindReward(itemName);
            if(itemFromContext == null)
            {
                SendMessage($"{itemName} could not be found amongst the body.");
                return false;
            }
            
            if(_context._player._inventory.isFull())
            {
                SendMessage("Your inventory is full! Drop an item or equip some items!");
                return false;
            }

            var res = _context._player._inventory.Insert(itemFromContext);
            if(res)
                SendMessage($"{itemName} added to your inventory.");
            
            return res;
        }

        [Command("combat", isInfoMethod: true)]
        public override bool DisplayCommands()
        {
            SendMessage(@"Here's some combat commands you can use: 
            > Attack 'item name' : Attack your opponent with your weapon
            > Defend 'item name' : Defend against an attack from you opponent (increases armor class rating)
            > Take 'item name' : Pick up an item dropped by your opponent
            > Exit : Quit the game
            ");

            return true;
        }
    }
}