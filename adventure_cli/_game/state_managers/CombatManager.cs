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
                        if (CombatCommands.doCommand(cmd, player, enemy)) 
                            _state = CombatState.ENEMY;
                        CheckWinCondition(player, enemy);
                        break;
                    }
                case CombatState.ENEMY:
                    {
                        enemy.AttackOther(player, (Weapon) enemy._equipped._Items.First.Value);
                        _state = CombatState.PLAYER;
                        CheckWinCondition(player, enemy);
                        break;
                    }
                case CombatState.WIN:
                    {
                        Console.WriteLine("You Win!");
                        break;
                    }
                case CombatState.LOSE:
                    {
                        Console.WriteLine("You Died!");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public static bool isCombatOver()
        {
            return _state == CombatState.LOSE || _state == CombatState.WIN ? true : false;
        }

        private static void CheckWinCondition(PlayerEntity player, EnemyEntity enemy)
        {
            if (player.isDead())
            {
                _state = CombatState.LOSE;
            }
            else if (enemy.isDead())
            {
                _state = CombatState.WIN;
            }
        }
    }
}