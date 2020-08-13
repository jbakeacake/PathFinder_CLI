using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Modules;

namespace Pathfinder_CLI.Game.StateManagers.Interfaces
{
    public interface IStateManagerBase<TContext, TState> where TContext : Context
    {
        void Run();
        void UpdateState(TState state);
        void AwaitCommand<TModule>(TState next) where TModule : ModuleBase<TContext>;
        TState GetState();
    }
}