using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._controllers;
using adventure_cli._data;
using adventure_cli._game;
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
            Game game = new Game(_context);
            var potion = await game.GetPotion(1);
            var weapon = await game.GetWeapon(1);
            var armor = await game.GetArmor(1);
            EnemyEntity enemy = await game.GetCharacter<EnemyEntity>(1);
            PlayerEntity player = await game.GetCharacter<PlayerEntity>(999);
            player._inventory.Insert(potion);
            player._inventory.Insert(weapon);
            player._inventory.Insert(weapon);
            player._inventory.Insert(weapon);
            player._inventory.Insert(weapon);
            player._inventory.Insert(armor);
            var potionSet = await game.GetRandomPotionSet(3);
            var weaponSet = await game.GetRandomWeaponSet(3);
            var armorSet = await game.GetRandomArmorSet(3);

            Console.WriteLine(potion.ToString());
            Console.WriteLine(weapon.ToString());
            Console.WriteLine(armor.ToString());
            Console.WriteLine(enemy.ToString());
            Console.WriteLine(player.ToString());

            while (true)
            {
                var cmdKey = Console.ReadLine();
                GeneralCommands.doCommand(cmdKey, player);
                Options.GetCombatOptions(player, enemy);
            }
        }
    }
}
