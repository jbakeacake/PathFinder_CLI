using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pathfinder_CLI.Data;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Models;

namespace Pathfinder_CLI.Controllers
{
    public class PotionController
    {
        private readonly IPathfinderRepository _repo;
        private readonly IMapper _mapper;
        
        public PotionController(IPathfinderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Potion> GetPotion(int id)
        {
            var potionDataFromRepo = await _repo.GetPotion(id);
            var potionToReturn = _mapper.Map<Potion>(potionDataFromRepo);
            return potionToReturn;
        }

        public async Task<IEnumerable<Potion>> GetPotions()
        {
            var potionsFromRepo = await _repo.GetPotions();
            var potionsToReturn = _mapper.Map<IEnumerable<Potion>>(potionsFromRepo);
            return potionsToReturn;
        }

        public async Task<Potion> GetRandomPotion()
        {
            var potionDataFromRepo = ((List<PotionData>)await _repo.GetPotions(1))[0];
            var potionToReturn = _mapper.Map<Potion>(potionDataFromRepo);
            return potionToReturn;
        }
    }
}