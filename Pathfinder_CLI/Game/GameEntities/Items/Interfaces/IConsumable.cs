using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items.Interfaces
{
    public interface IConsumable
    {
         void UseConsumable(ICombative character);
    }
}