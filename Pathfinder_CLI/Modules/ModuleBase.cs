using System;
using Microsoft.Extensions.DependencyInjection;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Modules.Interfaces;
using Pathfinder_CLI.Services;

namespace Pathfinder_CLI.Modules
{
    public abstract class ModuleBase<TContext> : IModuleBase<TContext> where TContext : Context
    {
        protected readonly IServiceProvider _provider;
        protected readonly TContext _context;

        public ModuleBase(IServiceProvider provider)
        {
            _provider = provider;
            _context = provider.GetRequiredService<CommandHandlingService>().GetCurrentContext<TContext>();
        }

        public abstract void DisplayCommands();

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}