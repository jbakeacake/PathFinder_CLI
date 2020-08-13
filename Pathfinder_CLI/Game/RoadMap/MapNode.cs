using System;
using Pathfinder_CLI.Game.Contexts;

namespace Pathfinder_CLI.Game.RoadMap
{
    public class MapNode
    {
        private readonly int NUM_ROLLS = 3;
        public Type _stateManagerType { get; set; }
        public Context _context { get; set; }
        public MapNode[] _nextPaths { get; set; } // List of all possible paths
        public string _title { get; set; } // Describes what the entrance to this path looks like (e.g. Thorny Path, Wooden Door, Bear Cave, etc.)
        public MapNode(Type stateManagerType, Context context, MapNode[] nextPaths)
        {
            _stateManagerType = stateManagerType;
            _context = context;
            _nextPaths = LinkPaths(nextPaths);
        }

        public MapNode() {}

        public MapNode[] LinkPaths(MapNode[] paths)
        {
            int numSlots = GetNumberOfSlots();
            MapNode[] pathsToReturn = new MapNode[numSlots];

            return pathsToReturn;
        }

        private int GetNumberOfSlots()
        {
            int chanceForExtraPathSlot = 100;
            Random rand = new Random();
            int rollsMade = 0;
            int numSlots = 0;
            while (rollsMade < NUM_ROLLS)
            {
                int rollForSlot = rand.Next(101);
                if (rollForSlot >= 100 - chanceForExtraPathSlot) // will always trigger on first iteration
                {
                    chanceForExtraPathSlot -= 40; // 100 : 0 -> 60 : 1 -> 20 : 2
                    numSlots += 1;
                }
                rollsMade += 1;
            }

            return numSlots;
        }
    }
}