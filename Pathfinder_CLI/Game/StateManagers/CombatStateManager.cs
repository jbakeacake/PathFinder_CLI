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
                    
                    AwaitCommand<CombatModule>(next: CombatStates.ENEMY);
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
                    OfferRewards(enemy);
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

        private void OfferRewards(EnemyEntity enemy)
        {
            Console.WriteLine($"You gained {_context._experienceWinnings} XP");
            Console.WriteLine($"You found {_context._goldWinnings} GP");
            Console.WriteLine($"{enemy._name} dropped the following:");
            Console.WriteLine("(Type out: take 'item name' to pickup an item)");
            AwaitCommand<CombatModule>(next: CombatStates.EXIT); // TODO: Transfer to reward state manager instead?
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