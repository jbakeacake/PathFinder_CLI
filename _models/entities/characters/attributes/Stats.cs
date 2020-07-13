using System;
using System.Collections.Generic;
using adventure_cli._models.entities.characters.attributes.stat_types;

namespace adventure_cli._models.player.attributes
{
    public class Stats
    {
        public int _maxHP { get; set; }
        public int _HP { get; set; } // Initial Value of 10 HP
        public int _XP { get; set; }
        public int _level { get; set; } // Based on the _XP (for now we'll use linear growth, 100 XP needed for each level) TODO: (Design) Exponential or Linear Growth for next level ?
        public Dictionary<string, Stat> _skills { get; set; } // A Dictionary/HashMap of our stats -- key is the name of the stat ('Strength', 'Dexterity', 'Intelligence'), while the value is the Stat holder
        // In order to effectively do damage to a creature, an Entity must roll damage higher than that of the Entity's ArmorClass Rating (DnD Rules)
        // For example:
        // Attacking Entity rolls a 1d20 of 15 --> Defending Entity has an AC 14 --> Attacking Entity can now roll damage
        // Attacking Entity rolls a 1d20 of 10 --> Defending Entity has an AC 14 --> Attacking Entity does NO damage (no roll)
        // Attacking Entity rolls a 1d20 of 18 --> Defending Entity has an AC 18 --> Attacking Entity can now roll damage
        //

        // BASE STATS
        //
        // Everything below is calculated via stats -- any additional modifications will be added on outside this class (i.e. if a player has armor or enchants
        // then they will be added on to these base stats)
        public int _armorClass { get; set; } // ArmorClass rating is based purely on Strength + AC of Armor (e.g. Plate has +5 AC, Leather has +3 AC)
        public int _speed { get; set; } // Speed is based purely on dexterity (Dex. Modifier of 1 gives +1 Speed)
        public int _spellSlots { get; set; } // Spell Slots is based purely on intelligence (Int. Modifier of 2 gives 2 spell slots)

        //Note: _skills will be pulled from a local database holding default stats for the PlayerEntity, as well as NPC/Enemy Entities
        public Stats(int maxHP, int XP, int level, Dictionary<string, Stat> skills)
        {
            _maxHP = maxHP;
            _HP = _maxHP;
            _XP = XP;
            _level = level;
            _skills = skills;
            _armorClass = skills["Strength"].GetModifier();
            _speed = skills["Dexterity"].GetModifier();
            _spellSlots = skills["Intelligence"].GetModifier();
        }

        public override String ToString()
        {
            string toRtn = "\n";
            toRtn += "--- STATS --- \n";
            toRtn += $"HP : {_HP} / {_maxHP} \n";
            toRtn += $"XP : {_XP} / {((_XP/100) + 1) * 100} \n";
            toRtn += $"Lvl : {_level} \n";
            toRtn += $"Defense : {_armorClass} \n";
            toRtn += $"Speed : {_speed} \n";
            toRtn += $"Spell Slots : {_spellSlots} \n";
            toRtn += "--- SKILLS --- \n";
            foreach(Stat skill in _skills.Values)
            {
                toRtn += $"{skill._name} : {skill._value} \n";
            }

            return toRtn;
        }
    }
}