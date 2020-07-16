using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.characterData;
using adventure_cli._models.entities.items.consumable;
using AutoMapper;

namespace adventure_cli._controllers
{
    public class PotionController
    {
        private readonly PotionRepository _repo;
        private readonly Mapper _mapper;
        public PotionController(PotionRepository repo, Mapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Potion> GetEntity(int id)
        {
            PotionData potionData = (PotionData)(await _repo.FetchOne(id)); // For now let's deal with having to cast our repo data
            Potion potion = _mapper.Map<Potion>(potionData);
            return potion;
        }

        public async Task<IEnumerable<Potion>> GetRandomSet(int numberInSet)
        {
            int tableCount = await _repo.GetCount();
            var rand = new Random();

            List<Potion> potionsToReturn = new List<Potion>();

            for (int i = 0; i < numberInSet; i++)
            {
                var potion = await this.GetEntity(rand.Next(1, tableCount + 1));
                potionsToReturn.Add(potion);
            }

            return potionsToReturn;
        }
    }
}