using Pathfinder_CLI.Game.GameEntities.Characters;

namespace Pathfinder_CLI.Game.GameEntities.Items.Interfaces
{
    public interface IConsumable
    {
         void Consume(PlayerEntity player);
    }
}