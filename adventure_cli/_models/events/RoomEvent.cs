using adventure_cli._models.entities;
using adventure_cli._models.entities.characters;
using adventure_cli._models.player;

namespace adventure_cli._models.events
{
    /**
    RoomEvent : Class

    RoomEvent contains data regarding any entities that may be contained within the room -- including interactables/door/obstacles/enemies. This will act as super
    class for any RoomEvents of this type.
    */
    public abstract class RoomEvent : IRoomEvent
    {
        public PlayerEntity _player { get; set; }
        public Entity[] _entities { get; set; } // Entities can be doors, enemies, obstacles, etc. These entities have a present need for verbal action -- i.e. a dynamic entity
        public IRewardable[] _rewards { get; set; } // a reward could be a item or just experience -- i.e. a static entity

        public RoomEvent(PlayerEntity player, Entity[] entities, IRewardable[] rewards)
        {
            _player = player;
            _entities = entities;
            _rewards = rewards;
        }
        public void RewardPlayer(PlayerEntity player)
        {
            foreach(var rewardable in _rewards)
            {
                rewardable.RewardToPlayer(player);
            }
        }
    }
}