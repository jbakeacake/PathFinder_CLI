using System;

namespace adventure_cli._models.entities.characters.attributes.stat_types
{
    /**
    Strength : Stat
    
    The Strength stat by default starts at 0 (this could be changed as classes are added on later).
    The main purpose of the strength stat is to increase damage, and to measure success on obstacles
    that require you to use strength (e.g. bashing a door in, prying something open, etc.)
    */
    public class Strength : Stat
    {
        public Strength(int value) : base("Strength", value)
        {}
    }
}