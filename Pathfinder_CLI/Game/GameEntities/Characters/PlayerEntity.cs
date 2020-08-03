using Pathfinder_CLI.Game.GameEntities.Characters.Helpers;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Game.GameEntities.Items.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Items.Spells.Types;

namespace Pathfinder_CLI.Game.GameEntities.Characters
{
    public class PlayerEntity : CharacterEntity, ITrader, ICombative
    {
        private ITrader _tradingHelper { get; set; }
        private ICombative _combatHelper { get; set; }
        public PlayerEntity(string name, string type, Stats stats, ItemContainer inventory, ItemContainer equipment) : base(name, type, stats, inventory, equipment)
        {
            _tradingHelper = new TradingHelper(stats, inventory);
            _combatHelper = new CombatHelper(this, name, stats, inventory);
        }

        public void BuyFromOther(CharacterEntity other, Item item)
        {
            _tradingHelper.BuyFromOther(other, item);
        }

        public void SellToOther(CharacterEntity other, Item item)
        {
            _tradingHelper.SellToOther(other, item);
        }

        public override string ToString()
        {
            string toRtn = _stats.ToString();
            toRtn += "\n";
            toRtn += _inventory.ToString();
            toRtn += "\n";
            toRtn += _equipment.ToString();

            return toRtn;
        }

        public void CombatAction(ICombative defender, Equipable equippedItem)
        {
            _combatHelper.CombatAction(defender, equippedItem);
        }

        public void ConsumePotion(Potion potion)
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

        public void UpdateCharacterStats(CharacterEntity character)
        {
            _combatHelper.UpdateCharacterStats();
        }

        public void UpdateCharacterStats()
        {
            _combatHelper.UpdateCharacterStats();
        }
    }
}