using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._controllers;
using adventure_cli._data;
using adventure_cli._game;
using adventure_cli._game.state_managers;
using adventure_cli._models.actions;
using adventure_cli._models.actions.commands;
using adventure_cli._models.characterData;
using adventure_cli._models.entities;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items.consumable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;
using adventure_cli.Helpers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using static adventure_cli._game.GameStateEnums;

namespace adventure_cli
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            //Set up DataContext and AutoMapper
            DataContext _context = new DataContext(); // TODO: use _context within a "using" statement to preserve memory
            //Seeding:
            Seed.SeedData(_context);

            Game game = new Game(_context);

            var potion = await game.GetPotion(1);
            var weapon = await game.GetWeapon(1);
            var armor = await game.GetArmor(1);
            EnemyEntity enemy = await game.GetCharacter<EnemyEntity>(1);
            PlayerEntity player = await game.GetCharacter<PlayerEntity>(999);

            GameState current = GameState.COMBAT;
            while (true)
            {
                switch (current)
                {
                    case GameState.ADVENTURE:
                        {
                            var cmdKey = Console.ReadLine();
                            GeneralCommands.doCommand(cmdKey, player);
                            break;
                        }
                    case GameState.COMBAT:
                        {
                            CombatManager.BeginCombat(player, enemy);
                            if (CombatManager.isCombatOver())
                            {
                                CombatManager.BeginCombat(player, enemy); // Run the combat command one more time for looting messages and win messages
                                current = GameState.ADVENTURE;
                            }
                            break;
                        }
                    case GameState.SHOP:
                        {
                            //ShopCommands.doCommand(cmdKey, player, shopkeep);
                            break;
                        }
                    case GameState.LEVELUP:
                        {
                            //LevelUpCommands.doCommand(cmdKey, player);
                            break;
                        }
                    default:
                        {
                            var cmdKey = Console.ReadLine();
                            GeneralCommands.doCommand(cmdKey, player);
                            break;
                        }
                }
            }
        }
    }
}
