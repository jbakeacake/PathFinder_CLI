using System;
using adventure_cli._models.entities.characters.attributes;
using adventure_cli._models.player.attributes;

namespace adventure_cli._models.entities.characters
{
    public class EnemyEntity : CharacterEntity
    {
        public EnemyEntity(int Id, string name, string type, Stats stats, Inventory inventory) : base(Id, name, type, stats, inventory)
        {
        }

        public void printFoo()
        {
            Console.WriteLine("HYAHHHH");
        }
    }
}