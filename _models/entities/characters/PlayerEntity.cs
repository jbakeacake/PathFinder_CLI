using System;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class PlayerEntity : CharacterEntity
    {
        private int _maxXP { get; set; }
        public PlayerEntity(int Id, string name, int XP, string type, Stats stats, Inventory inventory) : base(Id, name, true, XP, type, stats, inventory)
        {
            _maxXP = ((_XP / 100) + 1) * 100;
        }
        public void IncreaseXPCap()
        {
            _maxXP += 100;
        }

        public void IncreaseSkill(string skillName, int points)
        {
            if (!_stats._skills.ContainsKey(skillName)) throw new Exception("Skill to increase does not exist");

            _stats._skills[skillName].IncreaseValueBy(points);
            this.UpdateBaseStats();

        }
        private void UpdateBaseStats()
        {
            _stats._armorClass = _stats._skills["Strength"].GetModifier();
            _stats._speed = _stats._skills["Dexterity"].GetModifier();
            _stats._spellSlots = _stats._skills["Intelligence"].GetModifier();
        }

        public bool CanLevelUp()
        {
            if (_XP >= _maxXP) return true;

            return false;
        }
    }
}