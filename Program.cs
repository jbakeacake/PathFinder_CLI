using System;
using System.Threading.Tasks;
using adventure_cli._controllers;
using adventure_cli._data;
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
            Mapper _mapper = ConfigureMapper();
            //Declare Controllers:
            PotionController _potionController;
            WeaponController _weaponController;
            ArmorController _armorController;
            CharacterController _characterController;
            //Configure Controllers:
            ConfigureControllers(_context, _mapper, out _potionController, out _weaponController, out _armorController, out _characterController);
            var potion = await _potionController.GetEntity(1);
            var weapon = await _weaponController.GetEntity(1);
            var armor = await _armorController.GetEntity(1);
            EnemyEntity character = await _characterController.GetEntity<EnemyEntity>(1);
            PlayerEntity player = await _characterController.GetEntity<PlayerEntity>(999);
            var potionSet = await _potionController.GetRandomSet(3);
            var weaponSet = await _weaponController.GetRandomSet(3);
            var armorSet = await _weaponController.GetRandomSet(3);

            Console.WriteLine(potion.ToString());
            Console.WriteLine(weapon.ToString());
            Console.WriteLine(armor.ToString());
            Console.WriteLine(character.ToString());
            Console.WriteLine(player.ToString());
        }

        // TODO: Add Character and Armor Controllers
        public static void ConfigureControllers(DataContext context, Mapper mapper, out PotionController potionController, out WeaponController weaponController, out ArmorController armorController, out CharacterController characterController)
        {
            PotionRepository potionRepository = new PotionRepository(context);
            WeaponRepository weaponRepository = new WeaponRepository(context);
            ArmorRepository armorRepository = new ArmorRepository(context);
            CharacterRepository characterRepository = new CharacterRepository(context);

            potionController = new PotionController(potionRepository, mapper);
            weaponController = new WeaponController(weaponRepository, mapper);
            armorController = new ArmorController(armorRepository, mapper);
            characterController = new CharacterController(characterRepository, mapper);
        }
        public static Mapper ConfigureMapper()
        {
            // Initialize AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArmorData, Armor>();
                cfg.CreateMap<WeaponData, Weapon>();
                cfg.CreateMap<PotionData, Potion>();
            });

            return new Mapper(config);
        }
    }
}
