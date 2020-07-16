using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.entities.characters;
using AutoMapper;
using adventure_cli.Helpers;
using adventure_cli._models.characterData;
using System;
using System.Collections.Generic;

namespace adventure_cli._controllers
{
    public class CharacterController
    {
        private readonly CharacterRepository _repo;
        private readonly Mapper _mapper;
        public CharacterController(CharacterRepository repo, Mapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<T> GetEntity<T>(int id) where T : CharacterEntity
        {
            CharacterData characterData = (CharacterData)(await _repo.FetchOne(id)); // For now let's deal with having to cast our repo data
            T character = characterData.ConfigureCharacter<T>();
            return (T)character;
        }

        public async Task<IEnumerable<T>> GetRandomSet<T>(int numberInSet) where T : CharacterEntity
        {
            int tableCount = await _repo.GetCount();
            var rand = new Random();

            List<T> charactersToReturn = new List<T>();

            for (int i = 0; i < numberInSet; i++)
            {
                var character = await this.GetEntity<T>(rand.Next(1, tableCount + 1));
                charactersToReturn.Add(character);
            }

            return charactersToReturn;
        }
    }
}