using System.Collections.Generic;

namespace Pathfinder_CLI.Game.GameEntities.Common.Stats
{
    public class Stats
    {
        public int _maxHP { get; set; }
        public int _HP { get; set; }
        public int _XP { get; set; }
        public int _gold { get; set; }
        public int _level { get; set; }
        public Dictionary<string, Skill> _skills { get; set; }
        public int _baseDamage { get; set; }
        public int _armorClass { get; set; }
        public int _speed { get; set; }
        public int _spellSlots { get; set; }
        public Stats(int maxHP, int hP, int xP, int gold, Dictionary<string, Skill> skills)
        {
            _maxHP = maxHP;
            _HP = hP;
            _XP = xP;
            _gold = gold;
            _level = (_XP / 100) + 1; // so we don't start at level 0.
            _skills = skills;
            _baseDamage = skills["Strength"].GetModifier();
            _armorClass = skills["Strength"].GetModifier();
            _speed = skills["Dexterity"].GetModifier();
            _spellSlots = skills["Intelligence"].GetModifier();
        }

        public override string ToString()
        {
            string toRtn = "\n";
            toRtn += "--- STATS --- \n";
            toRtn += $"HP : {_HP} / {_maxHP} \n";
            toRtn += $"XP : {_XP} / {((_XP / 100) + 1) * 100} \n";
            toRtn += $"GP : {_gold} \n";
            toRtn += $"Lvl : {_level} \n";
            toRtn += $"Defense : {_armorClass} \n";
            toRtn += $"Speed : {_speed} \n";
            toRtn += $"Spell Slots : {_spellSlots} \n";
            toRtn += "--- SKILLS --- \n";
            foreach (Skill skill in _skills.Values)
            {
                toRtn += $"{skill._name} : {skill._value} \n";
            }

            return toRtn;
        }

        public int GetBaseDamage()
        {
            return _baseDamage;
        }
        public void RestoreToFullHP()
        {
            _HP = _maxHP;
        }
        public int GetHP()
        {
            return _HP;
        }

        public void SetHP(int updatedHP)
        {
            _HP = updatedHP;
        }

        public int GetXP()
        {
            return _XP;
        }

        public int GetGold()
        {
            return _gold;
        }

        public int GetLevel()
        {
            return _level;
        }

        public Dictionary<string, Skill> GetSkills()
        {
            return _skills;
        }

        public int GetArmorClass()
        {
            return _armorClass;
        }

        public void SetArmorClass(int updatedArmorClass)
        {
            _armorClass = updatedArmorClass;
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public int GetSpellSlots()
        {
            return _spellSlots;
        }
    }
}