using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;

namespace Pathfinder_CLI.Game.GameEntities.Characters
{
    public class CharacterEntity : ICharacterEntity
    {
        public CharacterEntity(string name,
        string type,
        Stats stats,
        Inventory inventory,
        Equipment equipment)
        {
            
        }
        public Equipment GetEquipment()
        {
            throw new System.NotImplementedException();
        }

        public Inventory GetInventory()
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            throw new System.NotImplementedException();
        }
    }
}