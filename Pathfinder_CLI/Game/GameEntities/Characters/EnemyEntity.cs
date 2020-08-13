using System;
using Pathfinder_CLI.Game.GameEntities.Characters.Helpers;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Spells.Types;

namespace Pathfinder_CLI.Game.GameEntities.Characters
{
    public class EnemyEntity : CharacterEntity, ICombative
    {
        private ICombative _combatHelper { get; set; }
        public EnemyEntity(string name, string type, Stats stats, ItemContainer inventory, ItemContainer equipment) : base(name, type, stats, inventory, equipment)
        {
            _combatHelper = new CombatHelper(this, name, stats, inventory);
        }

        public void CombatAction(ICombative defender, Equipable equippedItem)
        {
            _combatHelper.CombatAction(defender, equippedItem);
        }

        public void CombatAction(ICombative defender)
        {
            var equippedItem = _inventory._items.First.Value as Weapon; // for now, let's always assume that our enemy is going to attack
            _combatHelper.CombatAction(defender, equippedItem);
        }

        public void ConsumePotion(Item potion)
        {
            _combatHelper.ConsumePotion(potion);
        }

        public bool isDead()
        {
            return _combatHelper.isDead();
        }

        public void receiveDebuff(DebuffSpell debuff)
        {
            _combatHelper.receiveDebuff(debuff);
        }

        public void TakeDamage(int damage)
        {
            _combatHelper.TakeDamage(damage);
        }

        public Stats GetCombatStats()
        {
            return _combatHelper.GetCombatStats();
        }

        public void UpdateCharacterStats()
        {
            _combatHelper.UpdateCharacterStats();
        }
    }
}