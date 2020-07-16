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
        public Entity[] _entities { get; set; } // Entities can be doors, enemies, obstacles, etc. These entities have a present need for verbal action -- i.e. a dynamic entity
        public bool _hasCombat { get; set; }
        public Entity[] _rewards { get; set; } // a reward could be a item or just experience -- i.e. a static entity

        protected RoomEvent(Entity[] entities, bool hasCombat, Entity[] rewards)
        {
            _entities = entities;
            _hasCombat = hasCombat;
            _rewards = rewards;
        }
        public RoomEvent GetEvent()
        {
            throw new System.NotImplementedException();
        }
        public abstract void RewardPlayer(PlayerEntity player);

    }
}