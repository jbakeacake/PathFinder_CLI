using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pathfinder_CLI.Controllers;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.StateManagers;
using Pathfinder_CLI.Helpers;

namespace Pathfinder_CLI.Game.RoadMap
{
    public class Map
    {
        private readonly int MAP_LENGTH = 10;
        public MapNode _current { get; set; }
        public MapNode[,] _map { get; set; }
        public PlayerEntity _player { get; set; }
        private readonly IServiceProvider _provider;
        private readonly CharacterController _characterController;
        private readonly WeaponController _weaponController;
        private readonly ArmorController _armorController;
        private readonly PotionController _potionController;

        public Map(IServiceProvider provider, PlayerEntity player)
        {
            _provider = provider;
            _characterController = provider.GetRequiredService<CharacterController>();
            _weaponController = provider.GetRequiredService<WeaponController>();
            _armorController = provider.GetRequiredService<ArmorController>();
            _potionController = provider.GetRequiredService<PotionController>();
            _player = player;
        }

        public async Task InitializeMap()
        {
            _map = await GenerateMap();
            _current = _map[0,0];
        }

        private async Task<MapNode[,]> GenerateMap()
        {
            Random rand = new Random();
            int decrement = 33;

            MapNode[,] mapToReturn = new MapNode[3, MAP_LENGTH]; // 3 Rows, (MAP_LENGTH #) Columns
            mapToReturn[0, 0] = GenerateStartNode();

            // Column by Column Iteration
            for (int col = 1; col < mapToReturn.GetLength(1); col++)
            {
                int chanceForRoom = 100;
                for (int row = 0; row < mapToReturn.GetLength(0); row++)
                {
                    int rollForRoom = rand.Next(101);
                    if (rollForRoom < 100 - chanceForRoom)
                    {
                        chanceForRoom -= decrement;
                        mapToReturn[row, col] = await GenerateMapNode();
                    }
                }
            }

            return mapToReturn;
        }

        private void LinkNodesOnMap()
        {
            //start node will links to all adjacent paths
            for(int col = 1; col < _map.GetLength(1) - 1; col++)
            {
                MapNode[] mapNodesOfColumn = _map.GetColumn(col).Where(x => x != null).ToArray();
                MapNode[] nextPath = _map.GetColumn(col + 1).Where(x => x != null).ToArray();
                foreach(var node in mapNodesOfColumn)
                {
                    node.LinkPaths(nextPath);
                }
            }
        }

        private async Task<MapNode> GenerateMapNode()
        {
            (Type, Context) tup = await GenerateCombatEnvironment();
            MapNode nodeToReturn = new MapNode(tup.Item1, tup.Item2);

            return nodeToReturn;
        }

        private MapNode GenerateStartNode()
        {
            Type manager = typeof(AdventureStateManager);
            AdventureContext context = new AdventureContext(_player, "Welcome to Pathfinder! (v0.1)");
            MapNode nodeToReturn = new MapNode(manager, context);
            return nodeToReturn;
        }

        private async Task<(Type, CombatContext)> GenerateCombatEnvironment()
        {
            (Type, CombatContext) tupleToReturn;
            //For now let it just be CombatStateManager + CombatContext
            Random rand = new Random();

            EnemyEntity enemy = await _characterController.GetEnemy(1);
            Item[] rewards = (Item[]) await GenerateRandomRewards(3);

            CombatContext context = new CombatContext(_player, enemy, $"{enemy._name} appears!", rewards, enemy._stats._gold, enemy._stats._XP);
            tupleToReturn = (typeof(CombatStateManager), context);
            return tupleToReturn;
        }

        private async Task<IEnumerable<Item>> GenerateRandomRewards(int count)
        {
            Item[] rewardsToReturn = new Item[count];
            Random rand = new Random();
            //Equal chance for weapon, armor, or potion:
            int weaponMargin, armorMargin;
            weaponMargin = 33;
            armorMargin = 66;
            //Potion Margin is the remaining 33 percent (a roll between 66-100)
            for (int i = 0; i < count; i++)
            {
                int rollForItem = rand.Next(101);
                if (rollForItem <= weaponMargin)
                {
                    rewardsToReturn[i] = await _weaponController.GetRandomWeapon();
                }
                else if (rollForItem <= armorMargin)
                {
                    rewardsToReturn[i] = await _armorController.GetRandomArmor();
                }
                else
                {
                    rewardsToReturn[i] = await _potionController.GetRandomPotion();
                }
            }

            return rewardsToReturn;
        }
    }
}