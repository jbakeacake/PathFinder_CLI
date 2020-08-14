using System;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Modules;

namespace Pathfinder_CLI.Game.StateManagers
{
    public class AdventureStateManager : StateManagerBase<AdventureContext, AdventureStates>
    {
        public AdventureStateManager(IServiceProvider provider) : base(provider, AdventureStates.PLAYER) { }


        public override void Run()
        {
            var player = _context._player;
            switch (_state)
            {
                case AdventureStates.PLAYER:
                    {
                        doPlayerState(player);
                        break;
                    }
                case AdventureStates.EXIT:
                    {
                        break;
                    }
            }
        }

        private void doPlayerState(PlayerEntity player)
        {
            AwaitCommand<AdventureModule>(next: AdventureStates.EXIT);
        }
        public override bool IsExitingState()
        {
            return _state == AdventureStates.EXIT ? true : false;
        }
    }
}