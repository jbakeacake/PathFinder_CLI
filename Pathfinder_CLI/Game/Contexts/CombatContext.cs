using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Game.Contexts
{
    public class CombatContext : Context
    {
        public Item[] _rewards { get; set; }
        public int _goldWinnings { get; set; }
        public int _experienceWinnings { get; set; }
        public CombatContext(PlayerEntity player,
        EnemyEntity other,
        string description,
        Item[] rewards,
        int goldWinnings,
        int experienceWinnings) : base(player, other, description)
        {
            _rewards = rewards;
            _goldWinnings = goldWinnings;
            _experienceWinnings = experienceWinnings;
        }
    }
}