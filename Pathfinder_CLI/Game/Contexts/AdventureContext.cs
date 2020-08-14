using Pathfinder_CLI.Game.GameEntities.Characters;

namespace Pathfinder_CLI.Game.Contexts
{
    public class AdventureContext : Context
    {
        public string[] _pathTitles { get; set; }
        public AdventureContext(PlayerEntity player, 
        string description) : base(player, description)
        {}
    }
}