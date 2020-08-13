using System;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.StateManagers;

namespace Pathfinder_CLI.Game.RoadMap
{
    public class Map
    {
        private readonly int MAP_LENGTH = 10;
        public MapNode _current { get; set; }
        public MapNode[,] _map { get; set; }


        private MapNode[,] GenerateMap()
        {
            Random rand = new Random();
            int decrement = 33;

            MapNode[,] mapToReturn = new MapNode[3, MAP_LENGTH]; // 3 Rows, (MAP_LENGTH #) Columns
            // Column by Column Iteration
            for(int col = 0; col < mapToReturn.GetLength(1); col++)
            {
                int chanceForRoom = 100;
                for(int row = 0; row < mapToReturn.GetLength(0); row++)
                {
                    int rollForRoom = rand.Next(101);
                    if (rollForRoom < 100 - chanceForRoom)
                    {
                        chanceForRoom -= decrement;
                        mapToReturn[row, col] = new MapNode();
                    }
                }
            }

            return mapToReturn;
        }
    }
}