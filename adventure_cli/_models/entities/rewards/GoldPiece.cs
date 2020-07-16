using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.rewards
{
    public class GoldPiece : IRewardable
    {
        public int _goldAmount { get; set; }
        public GoldPiece(int goldAmount)
        {
            _goldAmount = goldAmount;
        }
        public void RewardToPlayer(PlayerEntity player)
        {
            player._stats._gold += _goldAmount;
        }
    }
}