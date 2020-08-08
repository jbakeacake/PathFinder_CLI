using Pathfinder_CLI.Game.Contexts;

namespace Pathfinder_CLI.Modules.Interfaces
{
    public interface IModuleBase<TContext> where TContext : Context
    {
        void SendMessage(string message);
        void DisplayCommands();
    }
}