using System;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class EnemyEntity : CharacterEntity, ICombatEntity
    {
        private Stats _tempStats;
        public EnemyEntity(int Id, string name, string type, Stats stats, Inventory<Item> inventory, Inventory<Equipable> equipment) : base(Id, name, type, stats, inventory, equipment)
        {
        }

        public void TakeDamage(int damage)
        {
            _stats._HP -= damage;
        }
        public bool isDead()
        {
            return _stats._HP <= 0 ? true : false;
        }

        private void UpdateModifiers(Stats stats)
        {
            stats._armorClass = _stats._skills["Strength"].GetModifier();
            stats._speed = _stats._skills["Dexterity"].GetModifier();
            stats._spellSlots = _stats._skills["Intelligence"].GetModifier();
        }

        public void ApplyDebuff(string skillToDebuff, int reductionValue)
        {
            _tempStats._skills[skillToDebuff]._value -= reductionValue;
            UpdateModifiers(_tempStats);
        }
    }
}