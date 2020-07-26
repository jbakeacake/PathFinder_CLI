using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Spells.Types;

namespace Pathfinder_CLI.Game.GameEntities.Characters
{
    public class PlayerEntity : CharacterEntity, ICombatEntity
    {
        public PlayerEntity(string name, string type, Stats stats, Inventory inventory, Equipment equipment) : base(name, type, stats, inventory, equipment)
        {
        }

        public void CombatAction(ICombatEntity defender, IEquipable equippedItem)
        {
            throw new System.NotImplementedException();
        }

        public void dodgeAttack(ICombatEntity attacker)
        {
            throw new System.NotImplementedException();
        }

        public Stats GetStats()
        {
            throw new System.NotImplementedException();
        }

        public bool isDead()
        {
            throw new System.NotImplementedException();
        }

        public void receiveDebuff(DebuffSpell debuff)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}