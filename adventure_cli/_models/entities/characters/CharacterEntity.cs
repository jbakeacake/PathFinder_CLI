using System;
using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class CharacterEntity : Entity
    {
        public string _type { get; set; }
        public int _level { get; set; }
        public Stats _stats { get; set; }
        public Inventory _inventory { get; set; }

        public CharacterEntity(int Id, string name, string type, Stats stats, Inventory inventory) : base(Id, name)
        {
            _type = type;
            _level = stats._XP / 100;
            _stats = stats;
            _inventory = inventory;
        }
        public CharacterEntity(int Id, string name, string type, Stats stats) : base(Id, name)
        {
            _type = type;
            _level = stats._XP / 100;
            _stats = stats;
            _inventory = new Inventory();
        }
        public override string ToString()
        {
            return $"> {_name} | Level : {_level} | HP: {_stats._HP} / {_stats._maxHP}";
        }
    }
}