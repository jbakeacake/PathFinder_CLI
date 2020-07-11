using System;
using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public abstract class CharacterEntity : Entity
    {
        public int _XP { get; set; }
        public int _level { get; set; }
        public Stats _stats { get; set; }
        public Inventory _inventory { get; set; }

        public CharacterEntity(int Id, string name, bool interactable, int XP, Stats stats, Inventory inventory) : base(Id, name, interactable)
        {
            _XP = XP;
            _level = _XP / 100;
            _stats = stats;
            _inventory = inventory;
        }
        public void printNameAndLevel() {
            Console.WriteLine($"{_name} | {_level}");
        }
        public void printStats()
        {

        }
        public void printInventory()
        {

        }

    }
}