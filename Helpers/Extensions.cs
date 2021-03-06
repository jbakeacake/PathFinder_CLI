using System;
using System.Collections.Generic;
using adventure_cli._models.characterData;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.entities.characters.attributes.stat_types;
using adventure_cli._models.player.attributes;

namespace adventure_cli.Helpers
{
    public static class Extensions
    {
        public static T ConfigureCharacter<T>(this CharacterData data) where T : CharacterEntity
        {
            Dictionary<string, Stat> skills = new Dictionary<string, Stat>();
            skills.Add("Strength", new Strength(data.Strength));
            skills.Add("Dexterity", new Strength(data.Dexterity));
            skills.Add("Intelligence", new Strength(data.Intelligence));

            Stats stats = new Stats(data.Max_HP, data.XP, data.Level, skills);

            return (T) Activator.CreateInstance(typeof(T), data.Id, data.Name, data.XP, data.Type, stats, new Inventory());
        }
    }
}