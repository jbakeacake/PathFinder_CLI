using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Pathfinder_CLI.Game.Commands;
using Pathfinder_CLI.Game.Commands.Attributes;
using Pathfinder_CLI.Game.Contexts;

namespace Pathfinder_CLI.Services
{
    public class CommandHandlingService
    {
        public Context _context { get; set; }
        public Dictionary<string, (object, MethodInfo)> _commandMap { get; set; }
        public Dictionary<string, Type> _typeMap { get; set; }
        private IServiceProvider _provider { get; set; }

        public CommandHandlingService(IServiceProvider provider)
        {
            _provider = provider;
            _commandMap = new Dictionary<string, (object, MethodInfo)>();
            _typeMap = new Dictionary<string, Type>();
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

        public bool Execute(string input)
        {
            var parseResults = CommandParser.ParseInput(input);
            if (parseResults == null)
                return false;

            var command = parseResults.Take(1).First().ToLower();
            var parameters = parseResults.Skip(1).Take(parseResults.Count() - 1).ToArray();

            (object, MethodInfo) tup;
            var res = _commandMap.TryGetValue(command, out tup);
            if(!res)
                return false;

            var (obj, method) = tup;

            if(method.GetParameters().Count() != parameters.Length)
            {
                Console.WriteLine($"Invalid amount of parameters! Make sure you're using the command, '{command}' correctly.");
                return false;
            }
            bool methodSuccess = (bool) method.Invoke(obj, parameters);
            return methodSuccess;
        }

        public void BuildCommands()
        {
            var methods = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()) // Select all types in our project
                .Where(x => x.IsClass) // filter by classes
                .SelectMany(x => x.GetMethods()) // select all methods in valid classes
                .Where(x => x.GetCustomAttributes(typeof(CommandAttribute), false).FirstOrDefault() != null); // filter by our command attribute

            // Iterate through each method with a CommandAttribute and add to our command map
            foreach(var method in methods)
            {
                var attr = (CommandAttribute) Attribute.GetCustomAttribute(method, typeof(CommandAttribute)); // get the attribute of the method
                var key = attr.Text.ToLower();
                var obj = Activator.CreateInstance(method.DeclaringType, new object[]{ _provider }); // create an instance of the class that the method is found in
                // _commandMap.Add(key, (Action<string>) Delegate.CreateDelegate(typeof(Action<string>), obj, method));
                _typeMap.Add(key, method.DeclaringType);
                _commandMap.Add(key, (obj, method));
            }
        }
    }
}