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
        public CombatStateManager(IServiceProvider provider) : base(provider, CombatStates.PLAYER) {} // always start with the player

        public override void Run()
        {
            var player = _context._player;
            var enemy = _context._other as EnemyEntity;
            switch(_state)
            {
                case CombatStates.PLAYER:
                {
                    player.UpdateCharacterStats();
                    Console.WriteLine("\nPlayer Turn");
                    PrintPlayerAndEnemyHealth(player, enemy);
                    
                    AwaitCommand<CombatModule>(CombatStates.ENEMY);
                    DetermineConclusionState(player, enemy);
                    break;
                }
                case CombatStates.ENEMY:
                {
                    enemy.UpdateCharacterStats();
                    Console.WriteLine("\nEnemy Turn");
                    PrintPlayerAndEnemyHealth(player, enemy);
                    enemy.CombatAction(player);

                    UpdateState(CombatStates.PLAYER);
                    DetermineConclusionState(player, enemy);
                    break;
                }
                case CombatStates.WIN:
                {
                    Console.WriteLine("* * YOU WIN * *");
                    UpdateState(CombatStates.EXIT);
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

        private void DetermineConclusionState(PlayerEntity player, EnemyEntity enemy)
        {
            if(player.isDead())
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
    }
}