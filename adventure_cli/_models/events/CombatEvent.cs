using adventure_cli._models.entities;
using adventure_cli._models.entities.characters;

namespace adventure_cli._models.events
{
    public enum CombatState
    {
        Player,
        Enemy,
        Win,
        Lose
    }
    public class CombatEvent : RoomEvent
    {
        private CombatState _currentState { get; set; }
        public CombatEvent(PlayerEntity player, Entity[] entities, IRewardable[] rewards) : base(player, entities, rewards)
        {
        }

        public void CombatLoop(PlayerEntity player, EnemyEntity enemy)
        {
            while(!player.isDead() && !enemy.isDead())
            {

            }
        }

        private void SetCombatState(CombatState state)
        {
            _currentState = state;
        }
    }
}