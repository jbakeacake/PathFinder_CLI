using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.entities.items.equipable.weapon;
using AutoMapper;

namespace adventure_cli._controllers
{
    public class WeaponController
    {
        
        private readonly WeaponRepository _repo;
        private readonly IMapper _mapper;

        public WeaponController(WeaponRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Weapon> GetWeapon(int id)
        {
            var weaponFromRepo = await _repo.FetchOne(id);
            var weapon = _mapper.Map<Weapon>(weaponFromRepo);
            
            return weapon;
        }

        public async Task<IEnumerable<Weapon>> GetRandomWeaponSet(int numberInSet)
        {
            int weaponTableCount = await _repo.GetCount();
            var rand = new Random();

            List<Weapon> weaponsToReturn = new List<Weapon>();

            for(int i = 0; i < numberInSet; i++)
            {
                var potion = await this.GetWeapon(rand.Next(1, weaponTableCount + 1));
                weaponsToReturn.Add(potion);
            }

            return weaponsToReturn;
        }
    }
}