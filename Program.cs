using System;
using System.Threading.Tasks;
using adventure_cli._controllers;
using adventure_cli._data;
using adventure_cli._models.characterData;
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
            //Configure Controllers:
            ConfigureControllers(_context, _mapper, out _potionController, out _weaponController);
        }

        // TODO: Add Character and Armor Controllers
        public static void ConfigureControllers(DataContext context, Mapper mapper, out PotionController potionController, out WeaponController weaponController)
        {
            PotionRepository potionRepository = new PotionRepository(context);
            WeaponRepository weaponRepository = new WeaponRepository(context);

            potionController = new PotionController(potionRepository, mapper);
            weaponController = new WeaponController(weaponRepository, mapper);
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
