using System;
using Microsoft.Extensions.DependencyInjection;
using Pathfinder_CLI.Game.Commands;
using Pathfinder_CLI.Game.Commands.Attributes;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.RoadMap.Contexts;
using Pathfinder_CLI.Services;

namespace Pathfinder_CLI.Modules
{
    public class CombatModule
    {
        private readonly IServiceProvider _provider;
        private readonly CombatContext _combat;
        private PlayerEntity _player;
        private EnemyEntity _enemy;
        public CombatModule(IServiceProvider provider)
        {
            _provider = provider;
            _combat = provider.GetRequiredService<CommandHandlingService>().GetCurrentContext<CombatContext>();
            _player = _combat._player;
            _enemy = _combat._other as EnemyEntity;
        }

        [Command("attack")]
        public void Attack(string input)
        {
            // For now, we'll always assume that the second item in our input is the item name
            var weaponName = CommandParser.ParseInput(input)[1];
            var weapon = _player._equipment.Find(weaponName) as Weapon;
            if(weapon == null)
            {
                SendMessage($"{weaponName} not found in equipment!");
                return;
            }
            _player.CombatAction(_enemy, weapon);
        }

        [Command("defend")]
        public void Defend(string input)
        {
            var armorName = CommandParser.ParseInput(input)[1];
            var armor = _player._equipment.Find(armorName) as Armor;
            if (armor == null)
            {
                SendMessage($"{armorName} not found in equipment!");
                return;
            }
            _player.CombatAction(_enemy, armor);
        }

        private void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}