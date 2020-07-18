using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._controllers;
using adventure_cli._data;
using adventure_cli._models.characterData;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items.consumable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;
using AutoMapper;

namespace adventure_cli._game
{
    public class Game
    {
        public PotionController _potionController { get; set; }
        public WeaponController _weaponController { get; set; }
        public ArmorController _armorController { get; set; }
        public CharacterController _characterController { get; set; }

        public DataContext _context { get; set; }
        public Mapper _mapper { get; set; }
        public Game(DataContext context)
        {
            _context = context;
            ConfigureMapper();
            ConfigureControllers();
        }

        public async Task<Potion> GetPotion(int id)
        {
            return await _potionController.GetEntity(id);
        }

        public async Task<IEnumerable<Potion>> GetRandomPotionSet(int numberInSet)
        {
            return await _potionController.GetRandomSet(numberInSet);
        }

        public async Task<Weapon> GetWeapon(int id)
        {
            return await _weaponController.GetEntity(id);
        }

        public async Task<IEnumerable<Weapon>> GetRandomWeaponSet(int numberInSet)
        {
            return await _weaponController.GetRandomSet(numberInSet);
        }

        public async Task<Armor> GetArmor(int id)
        {
            return await _armorController.GetEntity(id);
        }

        public async Task<IEnumerable<Armor>> GetRandomArmorSet(int numberInSet)
        {
            return await _armorController.GetRandomSet(numberInSet);
        }

        public async Task<T> GetCharacter<T>(int id) where T : CharacterEntity
        {
            return await _characterController.GetEntity<T>(id);
        }

        private void ConfigureControllers()
        {
            PotionRepository potionRepository = new PotionRepository(_context);
            WeaponRepository weaponRepository = new WeaponRepository(_context);
            ArmorRepository armorRepository = new ArmorRepository(_context);
            CharacterRepository characterRepository = new CharacterRepository(_context);

            _potionController = new PotionController(potionRepository, _mapper);
            _weaponController = new WeaponController(weaponRepository, _mapper);
            _armorController = new ArmorController(armorRepository, _mapper);
            _characterController = new CharacterController(characterRepository, _mapper);
        }

        public void ConfigureMapper()
        {
            // Initialize AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArmorData, Armor>();
                cfg.CreateMap<WeaponData, Weapon>();
                cfg.CreateMap<PotionData, Potion>();
            });

            _mapper = new Mapper(config);
        }
    }


}