using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.entities.items.consumable;
using AutoMapper;

namespace adventure_cli._controllers
{
    public class PotionController
    {

        private readonly PotionRepository _repo;
        private readonly IMapper _mapper;

        public PotionController(PotionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Potion> GetPotion(int id)
        {
            var potionData = await _repo.FetchOne(id);
            var potion = _mapper.Map<Potion>(potionData);
            return potion;
        }

        public async Task<IEnumerable<Potion>> GetRandomPotionSet(int numberInSet)
        {
            int potionTableCount = await _repo.GetCount();
            var rand = new Random();

            List<Potion> potionsToReturn = new List<Potion>();

            for(int i = 0; i < numberInSet; i++)
            {
                var potion = await this.GetPotion(rand.Next(1, potionTableCount + 1));
                potionsToReturn.Add(potion);
            }

            return potionsToReturn;
        }
    }
}