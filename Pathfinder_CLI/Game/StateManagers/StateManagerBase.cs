using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using Pathfinder_CLI.Game.Commands;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.StateManagers.Interfaces;
using Pathfinder_CLI.Modules;
using Pathfinder_CLI.Services;

namespace Pathfinder_CLI.Game.StateManagers
{
    public abstract class StateManagerBase<TContext, TState> : IStateManagerBase<TContext, TState> where TContext : Context
    {
        protected TState _state { get; set; }
        protected TContext _context { get; set; }
        protected IServiceProvider _provider { get; }
        protected CommandHandlingService _service { get; set; }
        public StateManagerBase(IServiceProvider provider, [Optional] TState state)
        {
            _state = state;
            _service = provider.GetRequiredService<CommandHandlingService>();
            _context = _service.GetCurrentContext<TContext>();
            _provider = provider;
        }

        public TState GetState()
        {
            return _state;
        }
        public void UpdateState(TState state)
        {
            _state = state;
        }
        public void AwaitCommand<TModule>(TState next) where TModule : ModuleBase<TContext>
        {
            var input = Console.ReadLine();
            var parseResults = CommandParser.ParseInput(input);

            if (parseResults == null)
                return;

            var command = parseResults.Take(1).First().ToLower();

            _service.Execute(input);
            // Console.WriteLine(_service._typeMap[command].ToString());
            // Console.WriteLine(typeof(TModule));
            if (_service._typeMap[command].Equals(typeof(TModule)))
            {
                UpdateState(next);
            }
        }
        public abstract void Run();

    }
}