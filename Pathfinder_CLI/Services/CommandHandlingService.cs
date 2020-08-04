using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.Commands;
using Pathfinder_CLI.Game.Commands.Attributes;
using Pathfinder_CLI.Game.Contexts;

namespace Pathfinder_CLI.Services
{
    public class CommandHandlingService
    {
        public Context _context { get; set; }
        public Dictionary<string, Action<string>> _commandMap { get; set; }
        private IServiceProvider _provider { get; set; }

        public CommandHandlingService(IServiceProvider provider)
        {
            _provider = provider;
            _commandMap = new Dictionary<string, Action<string>>();
        }

        public CommandHandlingService Initialize(IServiceProvider provider)
        {
            _provider = provider;
            return this;
        }

        public CommandHandlingService InitializeContext(Context context)
        {
            _context = context;
            return this;
        }

        public T GetCurrentContext<T>() where T : Context
        {    
            return _context as T;
        }

        public void Execute(string input)
        {
            string command = CommandParser.ParseInput(input)[0].Trim();
            _commandMap[command](input);
        }

        public void BuildCommands()
        {
            var methods = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass)
                .SelectMany(x => x.GetMethods())
                .Where(x => x.GetCustomAttributes(typeof(CommandAttribute), false).FirstOrDefault() != null);

            foreach(var method in methods)
            {
                var attr = (CommandAttribute) Attribute.GetCustomAttribute(method, typeof(CommandAttribute)); // get the attribute of the method
                var key = attr.Text;
                var obj = Activator.CreateInstance(method.DeclaringType, new object[]{ _provider }); // create an instance of the class that the method is found in
                _commandMap.Add(key, (Action<string>) Delegate.CreateDelegate(typeof(Action<string>), obj, method));
            }
        }
    }
}