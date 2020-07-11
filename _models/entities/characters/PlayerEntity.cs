using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class PlayerEntity : CharacterEntity
    {
        public PlayerEntity(int Id, string name, bool interactable, int XP, Stats stats, Inventory inventory) : base(Id, name, interactable, XP, stats, inventory)
        {
        }
    }
}