using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pathfinder_CLI.Data;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Controllers
{
    public class WeaponController
    {
        private readonly IPathfinderRepository _repo;
        private readonly IMapper _mapper;

        public WeaponController(IPathfinderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Weapon> GetWeapon(int id)
        {
            var weaponDataFromRepo = await _repo.GetWeapon(id);
            var weaponToReturn = _mapper.Map<Weapon>(weaponDataFromRepo);
            return weaponToReturn;
        }

        public async Task<IEnumerable<Weapon>> GetWeapons()
        {
            var weaponsDataFromRepo = await _repo.GetWeapons();
            var weaponsToReturn = _mapper.Map<IEnumerable<Weapon>>(weaponsDataFromRepo);
            return weaponsToReturn;
        }

        public async Task<Weapon> GetRandomWeapon()
        {
            var weaponDataFromRepo = ((List<WeaponData>)await _repo.GetWeapons(1))[0];
            var weaponToReturn = _mapper.Map<Weapon>(weaponDataFromRepo);
            return weaponToReturn;
        }
    }
}