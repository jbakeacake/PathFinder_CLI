using System;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.items.consumable
{
    public class Potion : Item, IRewardable
    {
        public int _healValue { get; set; }

        public Potion(int Id, string name, int goldValue, int healValue) : base(Id, name, goldValue)
        {
            _healValue = healValue;
        }

        public void Consume(PlayerEntity player)
        {
            Console.WriteLine($"{_name} used. Healed for {_healValue}.");
            int healthAfterConsume = player._stats._HP + _healValue;
            if (healthAfterConsume >= player._stats._maxHP)
            {
                player._stats._HP = player._stats._maxHP;
            }
            else
            {
                player._stats._HP = healthAfterConsume;
            }
        }

        public override string ToString()
        {
            return $"> {_name} | {_goldValue}gp | Heals for {_healValue}";
        }

        public void RewardToPlayer(PlayerEntity player)
        {
            player._inventory.Insert(this);
        }
    }
}