using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.characterData;
using adventure_cli._models.entities.items.equipable.weapon;
using AutoMapper;

namespace adventure_cli._controllers
{
    public class WeaponController
    {
        private readonly WeaponRepository _repo;
        private readonly Mapper _mapper;
        public WeaponController(WeaponRepository repo, Mapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Weapon> GetEntity(int id)
        {
            WeaponData weaponData = (WeaponData)(await _repo.FetchOne(id)); // For now let's deal with having to cast our repo data
            Weapon weapon = _mapper.Map<Weapon>(weaponData);
            return weapon;
        }

        public async Task<IEnumerable<Weapon>> GetRandomSet(int numberInSet)
        {
            int tableCount = await _repo.GetCount();
            var rand = new Random();

            List<Weapon> weaponsToReturn = new List<Weapon>();

            for (int i = 0; i < numberInSet; i++)
            {
                var weapon = await this.GetEntity(rand.Next(1, tableCount + 1));
                weaponsToReturn.Add(weapon);
            }

            return weaponsToReturn;
        }
    }
}