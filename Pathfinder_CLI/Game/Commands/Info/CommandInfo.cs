using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Pathfinder_CLI.Game.Commands.Info
{

    // CommandInfo : class
    // This object contains the information of a command, including the module of the command.
    //
    [DebuggerDisplay("{Name}")]
    public class CommandInfo
    {
        private static readonly System.Reflection.MethodInfo _convertParamsMethod = typeof(CommandInfo).GetTypeInfo().GetDeclaredMethod(nameof(ConvertParamsList));
        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<object>, object>> _arrayConverters = new ConcurrentDictionary<Type, Func<IEnumerable<object>, object>>();
        public IReadOnlyList<Attribute> Attributes { get; }
        public IReadOnlyList<ParameterInfo> Parameters { get; set; }

        

        private static T[] ConvertParamsList<T>(IEnumerable<object> paramsList)
            => paramsList.Cast<T>().ToArray();
    }
}