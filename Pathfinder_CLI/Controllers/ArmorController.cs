using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pathfinder_CLI.Data;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Controllers
{
    public class ArmorController
    {
        private readonly IPathfinderRepository _repo;
        private readonly IMapper _mapper;

        public ArmorController(IPathfinderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Armor> GetArmor(int id)
        {
            var armorDataFromRepo = await _repo.GetArmor(id);
            var armorToReturn = _mapper.Map<Armor>(armorDataFromRepo);
            return armorToReturn;
        }

        public async Task<IEnumerable<Armor>> GetArmors()
        {
            var armorsDataFromRepo = await _repo.GetArmors();
            var armorsToReturn = _mapper.Map<IEnumerable<Armor>>(armorsDataFromRepo);
            return armorsToReturn;
        }

        public async Task<Armor> GetRandomArmor()
        {
            var armorDataFromRepo = ((List<ArmorData>) await _repo.GetArmors(1))[0];
            var armorToReturn = _mapper.Map<Armor>(armorDataFromRepo);
            return armorToReturn;
        }
    }
}