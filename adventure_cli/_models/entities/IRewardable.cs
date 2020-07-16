using adventure_cli._models.entities.characters;

namespace adventure_cli._models.entities
{
    public interface IRewardable
    {
        void RewardToPlayer(PlayerEntity player); 
    }
}