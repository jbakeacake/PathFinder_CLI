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
        public void Attack(string weaponName)
        {
            var weapon = _player._equipment.Find(weaponName) as Weapon;
            if (weapon == null)
            {
                SendMessage($"{weaponName} not found in equipment!");
                return;
            }
            _player.CombatAction(_enemy, weapon);
        }

        [Command("defend")]
        public void Defend(string armorName)
        {
            var armor = _player._equipment.Find(armorName) as Armor;
            if (armor == null)
            {
                SendMessage($"Invalid item: '{armorName}'!");
                return;
            }
            _player.CombatAction(_enemy, armor);
        }

        [Command("combat")]
        public override void DisplayCommands()
        {
            SendMessage(@"Here's some combat commands you can use: 
            > Attack 'item name' : Attack your opponent with your weapon
            > Defend 'item name' : Defend against an attack from you opponent (increases armor class rating)
            > Exit : Quit the game
            ");
        }
    }
}