using System;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.StateManagers.Interfaces;
using Pathfinder_CLI.Modules;
using Pathfinder_CLI.Services;

namespace Pathfinder_CLI.Game.StateManagers
{
    public class CombatStateManager : StateManagerBase<CombatContext, CombatStates>
    {
        public CombatStateManager(IServiceProvider provider) : base(provider, CombatStates.PLAYER) { } // always start with the player

        public override void Run()
        {
            var player = _context._player;
            var enemy = _context._other as EnemyEntity;
            switch (_state)
            {
                case CombatStates.PLAYER:
                    {
                        doPlayerState(player, enemy);
                        break;
                    }
                case CombatStates.ENEMY:
                    {
                        doEnemyState(player, enemy);
                        break;
                    }
                case CombatStates.WIN:
                    {
                        doWinState(player);
                        break;
                    }
                case CombatStates.LOSE:
                    {
                        Console.WriteLine(". . YOU LOSE! . .");
                        UpdateState(CombatStates.EXIT);
                        break;
                    }
                case CombatStates.EXIT:
                    {
                        break;
                    }
            }
        }

        private void doEnemyState(PlayerEntity player, EnemyEntity enemy)
        {
            enemy.UpdateCharacterStats();
            Console.WriteLine("\nEnemy Turn");
            PrintPlayerAndEnemyHealth(player, enemy);
            enemy.CombatAction(player);

            UpdateState(CombatStates.PLAYER);
            DetermineConclusionState(player, enemy);
        }

        private void doPlayerState(PlayerEntity player, EnemyEntity enemy)
        {
            player.UpdateCharacterStats();
            Console.WriteLine("\nPlayer Turn");
            PrintPlayerAndEnemyHealth(player, enemy);

            AwaitCommand<CombatModule>(next: CombatStates.ENEMY);
            DetermineConclusionState(player, enemy);
        }

        private void doWinState(PlayerEntity player)
        {
            Console.WriteLine("* * YOU WIN * *");
            player._stats._XP += _context._experienceWinnings;
            player._stats._gold += _context._goldWinnings;
        }

        private void DetermineConclusionState(PlayerEntity player, EnemyEntity enemy)
        {
            if (player.isDead())
            {
                UpdateState(CombatStates.LOSE);
            }
            else if (enemy.isDead())
            {
                UpdateState(CombatStates.WIN);
            }
        }

        private void PrintPlayerAndEnemyHealth(PlayerEntity player, EnemyEntity enemy)
        {
            string message = $"{player.CurrentHealthToString()} | {enemy.CurrentHealthToString()}";
            Console.WriteLine(message);
        }

        public override bool IsExitingState()
        {
            if(_state == CombatStates.EXIT)
                return true;
            
            return false;
        }
    }
}