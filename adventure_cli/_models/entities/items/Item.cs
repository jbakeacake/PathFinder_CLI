using System;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.items
{
    public abstract class Item : Entity, IRewardable
    {
        public int _goldValue { get; set; }
        protected Item(int Id, string name, int goldValue) : base(Id, name)
        {
            _goldValue = goldValue;
        }

        public abstract void Use(PlayerEntity player);

        public bool SellToPlayer(PlayerEntity player, CharacterEntity ShopOwner)
        {
            if (!CanBuy(player)) return false;

            player._inventory.Insert(this);
            ShopOwner._inventory.Remove(this);
            player._stats._gold -= _goldValue;
            return true;
        }

        public bool CanBuy(PlayerEntity player)
        {
            return _goldValue <= player._stats._gold;
        }

        public void SellToShopOwner(PlayerEntity player, CharacterEntity ShopOwner)
        {
            ShopOwner._inventory.Insert(this);
            player._inventory.Remove(this);
            player._stats._gold += _goldValue;
        }

        public void RewardToPlayer(PlayerEntity player)
        {
            player._inventory.Insert(this);
        }
    }
}