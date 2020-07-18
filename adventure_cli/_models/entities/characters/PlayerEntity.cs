using System;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class PlayerEntity : CharacterEntity, ICombatEntity
    {
        private int _maxXP { get; set; }
        private Stats _tempStats { get; set; } // When in battle, these are the stats to be used/updated -- this may be updated later depending on how I structure the combat flow
        public PlayerEntity(int Id, string name, string type, Stats stats, Inventory<Item> inventory, Inventory<Equipable> equipped) : base(Id, name, type, stats, inventory, equipped)
        {
            _maxXP = ((stats._XP / 100) + 1) * 100;
            _tempStats = _stats;
        }
        public void TakeDamage(int damage)
        {
            _stats._HP -= damage;
        }
        public bool isDead()
        {
            return _stats._HP <= 0 ? true : false;
        }
        
        public void IncreaseXPCap()
        {
            _maxXP += 100;
        }
        public void IncreaseSkill(string skillName, int points)
        {
            if (!_stats._skills.ContainsKey(skillName)) throw new Exception("Skill to increase does not exist");

            _stats._skills[skillName].IncreaseValueBy(points);
            UpdateModifiers(_stats);

        }
        public bool CanLevelUp()
        {
            return _stats._XP >= _maxXP ? true : false;
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