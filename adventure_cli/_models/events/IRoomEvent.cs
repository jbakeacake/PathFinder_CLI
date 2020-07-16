using adventure_cli._models.entities.characters;

namespace adventure_cli._models.events
{
    public interface IRoomEvent
    {
        RoomEvent GetEvent();
        void RewardPlayer(PlayerEntity player);
    }
}