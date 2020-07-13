using System;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.items.consumable
{
    public class Potion : Entity
    {
        public int _goldValue { get; set; }
        public int _healValue { get; set; }

        public Potion(int Id, string name, int goldValue, int healValue) : base(Id, name, true)
        {
            _goldValue = goldValue;
            _healValue = healValue;
        }

        public void Consume(PlayerEntity player)
        {
            Console.WriteLine($"{_name} used. Healed for {_healValue}.");
        }

        public override string ToString()
        {
            return $"> {_name} | {_goldValue}gp | Heals for {_healValue}";
        }
    }
}