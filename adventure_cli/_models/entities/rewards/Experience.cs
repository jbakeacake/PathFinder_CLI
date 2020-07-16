using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities.rewards
{
    public class Experience : IRewardable
    {
        public int _xpAmount { get; set; }
        public Experience(int xpAmount)
        {
            _xpAmount = xpAmount;
        }

        public void RewardToPlayer(PlayerEntity player)
        {
            player._stats._XP += _xpAmount;
        }
    }
}