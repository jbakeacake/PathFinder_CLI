using System;
using System.Runtime.InteropServices;

namespace Pathfinder_CLI.Game.Commands.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        public string Text { get; }
        public bool IsInfoMethod { get; }
        public CommandAttribute(string text, bool isInfoMethod = false)
        {
            Text = text;
            IsInfoMethod = isInfoMethod;
        }        
    }
}