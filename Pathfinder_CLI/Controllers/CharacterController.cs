using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pathfinder_CLI.Data;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Helpers;
using Pathfinder_CLI.Models;
using Pathfinder_CLI.Models.Interfaces;

namespace Pathfinder_CLI.Controllers
{
    public class CharacterController
    {
        private readonly IPathfinderRepository _repo;
        private readonly IMapper _mapper;

        public CharacterController(IPathfinderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PlayerEntity> GetPlayer(int id)
        {
            var playerDataFromRepo = await _repo.GetPlayer(id);
            List<Item> inventoryItems = await GetInventoryItems(playerDataFromRepo.Inventory);
            var inventory = new ItemContainer(8, "INVENTORY", inventoryItems.ToArray());
            List<Item> equipmentItems = await GetEquipmentItems(playerDataFromRepo.Equipment);
            var equipment = new ItemContainer(4, "EQUIPMENT", equipmentItems.ToArray());

            PlayerEntity playerToReturn = playerDataFromRepo.ConfigurePlayer(inventory, equipment);
            return playerToReturn;
        }

        public async Task<EnemyEntity> GetEnemy(int id)
        {
            var enemyDataFromRepo = await _repo.GetPlayer(id);
            List<Item> inventoryItems = await GetInventoryItems(enemyDataFromRepo.Inventory);
            var inventory = new ItemContainer(8, "INVENTORY", inventoryItems.ToArray());
            List<Item> equipmentItems = await GetEquipmentItems(enemyDataFromRepo.Equipment);
            var equipment = new ItemContainer(4, "EQUIPMENT", equipmentItems.ToArray());

            EnemyEntity enemyToReturn = enemyDataFromRepo.ConfigureEnemy(inventory, equipment);
            return enemyToReturn;
        }

        //TODO(Jake): GetNPC --> requires dialogue paths

        private async Task<List<Item>> GetEquipmentItems(ICollection<EquipmentData> equipmentData)
        {
            List<Item> itemsToReturn = new List<Item>();
            foreach (var data in equipmentData)
            {
                var item = await GetItemForContainer(data.ItemType, data.ItemId);
                itemsToReturn.Add(item);
            }

            return itemsToReturn;
        }

        private async Task<List<Item>> GetInventoryItems(ICollection<ItemData> itemData)
        {
            List<Item> itemsToReturn = new List<Item>();
            foreach (var data in itemData)
            {
                var item = await GetItemForContainer(data.ItemType, data.ItemId);
                itemsToReturn.Add(item);
            }

            return itemsToReturn;
        }

        private async Task<Item> GetItemForContainer(string Type, int itemId)
        {
            Item itemToReturn;
            switch (Type)
            {
                case "WEAPON":
                    {
                        var weaponData = await _repo.GetWeapon(itemId);
                        itemToReturn = _mapper.Map<Weapon>(weaponData);
                        return itemToReturn;
                    }
                case "ARMOR":
                    {
                        var armorData = await _repo.GetArmor(itemId);
                        itemToReturn = _mapper.Map<Armor>(armorData);
                        return itemToReturn;
                    }
                case "POTION":
                    {
                        var potionData = await _repo.GetPotion(itemId);
                        itemToReturn = _mapper.Map<Potion>(potionData);
                        return itemToReturn;
                    }
                default:
                    throw new ArgumentException("Invalid Item Type");
            }
        }
    }
}