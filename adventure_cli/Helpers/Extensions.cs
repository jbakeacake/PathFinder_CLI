using System;
using System.Collections.Generic;
using adventure_cli._data;
using adventure_cli._models.characterData;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.entities.characters.attributes.stat_types;
using adventure_cli._models.entities.items;
using adventure_cli._models.entities.items.equipable;
using adventure_cli._models.entities.items.equipable.armor;
using adventure_cli._models.entities.items.equipable.weapon;
using adventure_cli._models.player.attributes;

namespace adventure_cli.Helpers
{
    public static class Extensions
    {
        public static T ConfigureCharacter<T>(this CharacterData data, Inventory<Item> inventory, Inventory<Equipable> equipment) where T : CharacterEntity
        {
            Dictionary<string, Stat> skills = new Dictionary<string, Stat>();
            skills.Add("Strength", new Strength(data.Strength));
            skills.Add("Dexterity", new Dexterity(data.Dexterity));
            skills.Add("Intelligence", new Intelligence(data.Intelligence));

            Stats stats = new Stats(data.Max_HP, data.XP, data.Gold, data.Level, skills);
        
            return (T)Activator.CreateInstance(typeof(T), data.Id, data.Name, data.Type, stats, inventory, equipment);
        }
    }
}