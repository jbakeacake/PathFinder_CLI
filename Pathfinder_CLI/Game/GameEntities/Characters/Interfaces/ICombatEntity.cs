using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Spells.Types;

namespace Pathfinder_CLI.Game.GameEntities.Characters.Interfaces
{
    public interface ICombatEntity
    {
        void CombatAction(ICombatEntity defender, IEquipable equippedItem);
        void TakeDamage(int damage);
        void dodgeAttack(ICombatEntity attacker); // 'this' would be the defender
        void receiveDebuff(DebuffSpell debuff);
        Stats GetStats();
        string GetName();
        bool isDead();

    }
}