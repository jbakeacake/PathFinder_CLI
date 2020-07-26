using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Items
{
    public class Potion : IInventoryItem, IConsumable
    {
        public int _healValue { get; set; }



        public void Consume(PlayerEntity player)
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            throw new System.NotImplementedException();
        }

        public void Use(ICharacterEntity character)
        {
            throw new System.NotImplementedException();
        }
    }
}