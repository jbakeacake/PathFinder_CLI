using System;
using adventure_cli._models.actions.commands;
using adventure_cli._models.entities.characters;
using adventure_cli._models.entities.items.equipable.weapon;

namespace adventure_cli._game.state_managers
{
    public static class CombatManager
    {
        public static CombatState _state { get; set; }
        public enum CombatState
        {
            PLAYER,
            ENEMY,
            WIN,
            LOSE
        }
        public static void UpdateState(CombatState state)
        {
            _state = state;
        }

        public static void BeginCombat(PlayerEntity player, EnemyEntity enemy)
        {
            switch (_state)
            {
                case CombatState.PLAYER:
                    {
                        string cmd = Console.ReadLine();
                        CombatCommands.doCommand(cmd, player, enemy);
                        break;
                    }
                case CombatState.ENEMY:
                    {
                        enemy.AttackOther(player, (Weapon) enemy._equipped._Items.First.Value);
                        break;
                    }
                case CombatState.WIN:
                    {
                        break;
                    }
                case CombatState.LOSE:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}