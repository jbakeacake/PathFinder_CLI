using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.characterData;
using adventure_cli._models.entities.items.equipable.armor;
using AutoMapper;

namespace adventure_cli._controllers
{
    public class ArmorController
    {
        private readonly ArmorRepository _repo;
        private readonly Mapper _mapper;
        public ArmorController(ArmorRepository repo, Mapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Armor> GetEntity(int id)
        {
            ArmorData armorData = (ArmorData) (await _repo.FetchOne(id)); // For now let's deal with having to cast our repo data
            Armor armor = _mapper.Map<Armor>(armorData);
            return armor;
        }

        public async Task<IEnumerable<Armor>> GetRandomSet(int numberInSet)
        {
            int tableCount = await _repo.GetCount();
            var rand = new Random();

            List<Armor> armorsToReturn = new List<Armor>();

            for (int i = 0; i < numberInSet; i++)
            {
                var armor = await this.GetEntity(rand.Next(1, tableCount + 1));
                armorsToReturn.Add(armor);
            }

            return armorsToReturn;
        }
    }
}