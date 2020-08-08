using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Spells.Types;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Interfaces
{
    public interface ICombative
    {
        void CombatAction(ICombative other, Equipable equippedItem);
        Stats GetCombatStats();
        void UpdateCharacterStats(); 
        void TakeDamage(int damage);
        void ConsumePotion(Item item);
        void receiveDebuff(DebuffSpell debuff);
        bool isDead();
        string GetName();
    }
}