using System.Threading.Tasks;
using adventure_cli._data;
using adventure_cli._models.entities.characters;
using AutoMapper;
using adventure_cli.Helpers;
using adventure_cli._models.characterData;
using System;
using System.Collections.Generic;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.entities.items.equipable;

namespace adventure_cli._controllers
{
    public class CharacterController
    {
        private readonly CharacterRepository _repo;
        // Note:
        // I definitely don't like that we're connecting all controllers into this CharacterController,
        // but to really simplify how a character is pulled from our database, we need to include these
        // controllers. Otherwise, we'd be making more async calls outside of this class.
        //
        private readonly ArmorController _armorController;
        private readonly PotionController _potionController;
        private readonly WeaponController _weaponController;
        private readonly Mapper _mapper;
        public CharacterController(CharacterRepository repo, Mapper mapper, ArmorController armorController, PotionController potionController, WeaponController weaponController)
        {
            _repo = repo;
            _armorController = armorController;
            _potionController = potionController;
            _weaponController = weaponController;
            _mapper = mapper;
        }
        public async Task<T> GetEntity<T>(int id) where T : CharacterEntity
        {
            CharacterData characterData = (CharacterData)(await _repo.FetchOne(id)); // For now let's deal with having to cast our repo data
            Inventory<Item> inventory = await configureInventoryData(8, "INVENTORY", characterData.Inventory);
            Inventory<Equipable> equipment = await configureEquipmentData(4, "EQUIPMENT", characterData.Equipment);
            T character = characterData.ConfigureCharacter<T>(inventory, equipment);
            return (T)character;
        }

        private async Task<Inventory<Item>> configureInventoryData(int slots, string name, ICollection<ItemData> itemData)
        {
            Inventory<Item> inventoryToRtn = new Inventory<Item>(slots, name);
            foreach (ItemData data in itemData)
            {
                Item toInsert = await GetItemBasedOnType(data);
                inventoryToRtn.Insert(toInsert);
            }
            return inventoryToRtn;
        }

        private async Task<Inventory<Equipable>> configureEquipmentData(int slots, string name, ICollection<EquipmentData> equipmentData)
        {
            Inventory<Equipable> equipmentToRtn = new Inventory<Equipable>(slots, name);
            foreach (EquipmentData data in equipmentData)
            {
                Item toInsert = await GetEquipmentBasedOnType(data);
                equipmentToRtn.Insert((Equipable)toInsert);
            }
            
            return equipmentToRtn;
        }

        private async Task<Item> GetItemBasedOnType(ItemData data)
        {
            switch (data.ItemType.ToUpper())
            {
                case "WEAPON":
                    {
                        return await _weaponController.GetEntity(data.ItemId);
                    }
                case "ARMOR":
                    {
                        return await _armorController.GetEntity(data.ItemId);
                    }
                case "POTION":
                    {
                        return await _potionController.GetEntity(data.ItemId);
                    }
                default:
                    {
                        throw new ArgumentException("ItemData 'ItemType' does not contain a valid type. Please make sure this item is of type WEAPON, ARMOR, or POTION");
                    }
            }
        }
        private async Task<Item> GetEquipmentBasedOnType(EquipmentData data)
        {
            if (data.ItemType.ToUpper() == "WEAPON")
            {
                return await _weaponController.GetEntity(data.ItemId);
            }
            else if (data.ItemType.ToUpper() == "ARMOR")
            {
                return await _armorController.GetEntity(data.ItemId);
            }
            else
            {
                throw new ArgumentException("EquipmentData 'ItemType' does not contain a valid type. Make sure this item is of type WEAPON or ARMOR");
            }
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