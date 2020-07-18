using System.Runtime.InteropServices;
using adventure_cli._models.entities;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.actions
{
    public interface IAction
    {
         void doAction(PlayerEntity player, [Optional] CharacterEntity other);
         string ToString();
    }
}